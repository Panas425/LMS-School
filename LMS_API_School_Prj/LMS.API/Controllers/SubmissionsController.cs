using LMS.API.Data;
using LMS.API.Models.Dtos;
using LMS.API.Models.Dtos.Mapper;
using LMS.API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SubmissionsController(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET submissions by activity
        [HttpGet("activity/{activityId}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetSubmissionsByActivity(Guid activityId)
        {
            var submissions = await _context.Submissions
                .Where(s => s.ActivityId == activityId)
                .Select(s => new SubmissionDto
                {
                    Id = s.Id.ToString(),
                    FileName = s.FileName,
                    FileUrl = s.FileUrl,
                    Activity = new ActivityDto
                    {
                        Id = s.Activity.Id,
                        Name = s.Activity.Name
                    },
                    StudentId = s.StudentId,
                    StudentName = _context.Users
                        .Where(u => u.Id == s.StudentId)
                        .Select(u => u.FirstName + " " + u.LastName)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return Ok(submissions);
        }

        // GET submissions by student
        [HttpGet("student/{studentId}")]
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> GetSubmissionsByStudent(string studentId)
        {
            var student = await _userManager.FindByIdAsync(studentId);
            if (student == null)
                return NotFound("Student not found.");

            var submissions = await _context.Submissions
                .Where(s => s.StudentId == studentId)
                .Select(s => new SubmissionDto
                {
                    Id = s.Id.ToString(),
                    FileName = s.FileName,
                    FileUrl = s.FileUrl,
                    Activity = s.Activity == null ? null : new ActivityDto
                    {
                        Id = s.Activity.Id,
                        Name = s.Activity.Name
                    },
                    StudentId = student.Id,
                    StudentName = student.FullName
                })
                .ToListAsync();

            return Ok(submissions);
        }

        // POST upload submission
        [HttpPost("upload")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> UploadSubmission(
            [FromForm] IFormFile file,
            [FromForm] Guid activityId,
            [FromForm] DateTime? deadline)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var submissionsPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedSubmissions");
            if (!Directory.Exists(submissionsPath))
                Directory.CreateDirectory(submissionsPath);

            var filePath = Path.Combine(submissionsPath, file.FileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            var student = await _userManager.FindByIdAsync(userId);
            if (student == null)
                return NotFound("Student not found.");

            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FileUrl = $"/UploadedSubmissions/{file.FileName}",
                ActivityId = activityId,
                StudentId = student.Id,
                StudentName = student.FullName,
                SubmittedAt = DateTime.UtcNow,
                Deadline = deadline
            };

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            var activityName = await _context.Activities
                .Where(a => a.Id == activityId)
                .Select(a => a.Name)
                .FirstOrDefaultAsync() ?? "Unknown";

            var submissionDto = new SubmissionDto
            {
                Id = submission.Id.ToString(),
                FileName = submission.FileName,
                FileUrl = submission.FileUrl,
                Activity = new ActivityDto
                {
                    Id = activityId,
                    Name = activityName
                },
                StudentId = student.Id,
                StudentName = student.FullName
            };

            return Ok(submissionDto);
        }

        // DELETE submission
        [HttpDelete("{id}")]
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> DeleteSubmission(Guid id)
        {
            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null) return NotFound();

            _context.Submissions.Remove(submission);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
