using LMS.API.Data;
using LMS.API.Models.Dtos;
using LMS.API.Models.Entities;
using LMS.API.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

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
        if (string.IsNullOrWhiteSpace(userForRegistration.UserName))
        {
            // Generate username automatically: first 2 letters of first + last name + random number
            var randomNumber = new Random().Next(100, 999);
            userForRegistration.UserName = $"{userForRegistration.FirstName[..2]}{userForRegistration.LastName[..2]}{randomNumber}".ToLower();

            // Ensure unique username
            while (await _userManager.FindByNameAsync(userForRegistration.UserName) != null)
            {
                randomNumber = new Random().Next(100, 999);
                userForRegistration.UserName = $"{userForRegistration.FirstName[..2]}{userForRegistration.LastName[..2]}{randomNumber}".ToLower();
            }
        }

        if (string.IsNullOrWhiteSpace(userForRegistration.Password))
        {
            // Generate a random password
            userForRegistration.Password = Path.GetRandomFileName()[..8];
        }

        // Validate student course assignment
        if (userForRegistration.Role?.ToLower() == "student" &&
            (userForRegistration.CourseIDs == null || !userForRegistration.CourseIDs.Any()))
        {
            return BadRequest("At least one assigned course is required for students.");
        }

        var result = await _serviceManager.AuthService.RegisterUserAsync(userForRegistration);
        if (!result.Succeeded) return BadRequest(result.Errors);

        // Assign courses if student
        if (userForRegistration.Role?.ToLower() == "student" && userForRegistration.CourseIDs != null)
        {
            var user = await _userManager.FindByNameAsync(userForRegistration.UserName);
            foreach (var courseIdStr in userForRegistration.CourseIDs)
            {
                if (Guid.TryParse(courseIdStr, out var courseId))
                {
                    _context.CourseUsers.Add(new CourseUser
                    {
                        UserId = user!.Id,
                        CourseId = courseId
                    });
                }
            }
            await _context.SaveChangesAsync();
        }

        return StatusCode(StatusCodes.Status201Created, new
        {
            Username = userForRegistration.UserName,
            Password = userForRegistration.Password
        });
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

    [HttpPost("upload-users")]
    [Obsolete]
    public async Task<IActionResult> UploadUsers([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty");

        var usersToRegister = new List<UserForRegistrationDto>();
        ExcelPackage.License.SetNonCommercialOrganization("Anas");


        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.First();
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // skip header
                {
                    var firstName = worksheet.Cells[row, 1].Text.Trim();
                    var lastName = worksheet.Cells[row, 2].Text.Trim();
                    var course = worksheet.Cells[row, 3].Text.Trim();
                    var role = worksheet.Cells[row, 4].Text.Trim();

                    if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                        continue;

                    // Generate username and password
                    var randomNumber = new Random().Next(100, 999);
                    var username = $"{firstName[..2]}{lastName[..2]}{randomNumber}".ToLower();
                    var password = Path.GetRandomFileName()[..8];

                    // Ensure unique username
                    while (await _userManager.FindByNameAsync(username) != null)
                    {
                        randomNumber = new Random().Next(100, 999);
                        username = $"{firstName[..2]}{lastName[..2]}{randomNumber}".ToLower();
                    }

                    usersToRegister.Add(new UserForRegistrationDto
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        UserName = username,
                        Password = password,
                        Email = $"{firstName}.{lastName}@example.com".ToLower(),
                        Role = role,
                        CourseIDs = string.IsNullOrEmpty(course) ? new List<string>() : new List<string> { course }
                    });
                }
            }
        }

        var createdUsers = new List<UserForRegistrationDto>();

        foreach (var userDto in usersToRegister)
        {
            var result = await _serviceManager.AuthService.RegisterUserAsync(userDto);
            if (result.Succeeded)
            {
                // Assign courses if student
                if (userDto.Role?.ToLower() == "student" && userDto.CourseIDs != null)
                {
                    var user = await _userManager.FindByNameAsync(userDto.UserName);
                    foreach (var courseIdStr in userDto.CourseIDs)
                    {
                        if (Guid.TryParse(courseIdStr, out var courseId))
                        {
                            _context.CourseUsers.Add(new CourseUser
                            {
                                UserId = user!.Id,
                                CourseId = courseId
                            });
                        }
                    }
                }
                createdUsers.Add(userDto);
            }
        }

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = $"{createdUsers.Count} users uploaded successfully",
            users = createdUsers
        });
    }
}

