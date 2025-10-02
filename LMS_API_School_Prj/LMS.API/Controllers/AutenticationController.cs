using LMS.API.Data;
using LMS.API.Models.Dtos;
using LMS.API.Models.Entities;
using LMS.API.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Controllers;


[Route("api/authentication")]
[ApiController]
public class AutenticationController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly DatabaseContext _context;
    private readonly UserManager<ApplicationUser> _userManager;


    public AutenticationController(IServiceManager serviceManager, DatabaseContext context, UserManager<ApplicationUser> userManager)
    {
        _serviceManager = serviceManager;
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        if (userForRegistration.Role?.ToLower() == "student")
        {
            if (userForRegistration.CourseIDs == null || !userForRegistration.CourseIDs.Any())
            {
                return BadRequest("At least one assigned course is required for students.");
            }

            // Validate that all provided course IDs exist
            foreach (var courseIdStr in userForRegistration.CourseIDs)
            {
                if (!Guid.TryParse(courseIdStr, out var courseId))
                {
                    return BadRequest($"Invalid course ID format: {courseIdStr}");
                }

                var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);
                if (!courseExists)
                {
                    return BadRequest($"Course not found: {courseId}");
                }
            }
        }

        // Call your AuthService to register the user
        var result = await _serviceManager.AuthService.RegisterUserAsync(userForRegistration);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        // If student, assign courses in the join table
        if (userForRegistration.Role?.ToLower() == "student" && userForRegistration.CourseIDs != null)
        {
            var user = await _userManager.FindByNameAsync(userForRegistration.UserName);
            foreach (var courseIdStr in userForRegistration.CourseIDs)
            {
                var courseId = Guid.Parse(courseIdStr);
                _context.CourseUsers.Add(new CourseUser
                {
                    UserId = user!.Id,
                    CourseId = courseId
                });
            }
            await _context.SaveChangesAsync();
        }

        return StatusCode(StatusCodes.Status201Created);
    }


    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate(UserForAuthenticationDto user)
    {
        if (!await _serviceManager.AuthService.ValidateUserAsync(user))
            return Unauthorized();

        TokenDto tokenDto = await _serviceManager.AuthService.CreateTokenAsync(expireTime: true);
        return Ok(tokenDto);
    }
}

