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

        // GET: api/submissions/activity/{activityId}
        [HttpGet("activity/{activityId}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetSubmissionsByActivity(Guid activityId)
        {
            var submissions = await _context.Submissions
                .Where(s => s.ActivityId == activityId)
                .Include(s => s.Student)
                .Select(s => new SubmissionDto
                {
                    Id = s.Id.ToString(),
                    FileName = s.FileName,
                    FileUrl = s.FileUrl,
                    Student = new StudentDto
                    {
                        Id = s.Student.Id,
                        UserName = s.Student.UserName
                    }
                })
                .ToListAsync();

            return Ok(submissions);
        }

        [HttpGet("student/{studentId}")]
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> GetSubmissionsByStudent(string studentId)
        {
            var submissions = await _context.Submissions
                .Where(s => s.StudentId == studentId)
                .Include(s => s.Activity)
                .Include(s => s.Student)
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
                    StudentId = s.Student.Id,
                    StudentName = $"{s.Student.FirstName} {s.Student.LastName}".Trim()
                })
                .ToListAsync();

            return Ok(submissions);
        }





        // POST: api/submissions/upload
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

            // Save the file locally
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // ✅ Get the current user ID from JWT
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            // ✅ Retrieve the student (ApplicationUser) from DB
            var student = await _userManager.FindByIdAsync(userId);
            if (student == null)
                return NotFound("Student not found.");

            // ✅ Create the submission with linked student
            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FileUrl = $"/UploadedSubmissions/{file.FileName}",
                ActivityId = activityId,
                StudentId = student.Id,   // FK
                Student = student,        // Navigation property
                SubmittedAt = DateTime.UtcNow,
                Deadline = deadline
            };

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            // ✅ Return a clean DTO with student info
            var submissionDto = new SubmissionDto
            {
                Id = submission.Id.ToString(),
                FileName = submission.FileName,
                FileUrl = submission.FileUrl,
                Activity = new ActivityDto
                {
                    Id = submission.ActivityId,
                    Name = (await _context.Activities
                        .Where(a => a.Id == activityId)
                        .Select(a => a.Name)
                        .FirstOrDefaultAsync()) ?? "Unknown"
                },
                StudentId = student.Id,
                StudentName = $"{student.FirstName} {student.LastName}".Trim()
            };

            return Ok(submissionDto);
        }


        // DELETE: api/submissions/{id}
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
