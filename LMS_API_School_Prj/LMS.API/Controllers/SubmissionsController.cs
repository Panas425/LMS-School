using LMS.API.Data;
using LMS.API.Models.Dtos;
using LMS.API.Models.Dtos.Mapper;
using LMS.API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public SubmissionsController(DatabaseContext context)
        {
            _context = context;
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

        // GET: api/submissions/student/{studentId}
        [HttpGet("student/{studentId}")]
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> GetSubmissionsByStudent(string studentId)
        {
            var submissions = await _context.Submissions
                .Where(s => s.StudentId == studentId)
                .Include(s => s.Activity)
                .Select(s => new SubmissionDto
                {
                    Id = s.Id.ToString(),
                    FileName = s.FileName,
                    FileUrl = $"/UploadedSubmissions/{s.FileName}",
                    Activity = new ActivityDto
                    {
                        Id = s.Activity.Id,
                        Name = s.Activity.Name
                    }
                })
                .ToListAsync();

            return Ok(submissions);
        }



        // POST: api/submissions/upload
        [HttpPost("upload")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> UploadSubmission([FromForm] IFormFile file, [FromForm] Guid activityId, [FromForm] DateTime? deadline)
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

            // Get the actual user ID from JWT to avoid FK conflict
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value
                         ?? throw new Exception("User ID not found");

            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FileUrl = $"/UploadedSubmissions/{file.FileName}", // Web-accessible URL
                ActivityId = activityId,
                StudentId = userId,
                SubmittedAt = DateTime.UtcNow,
                Deadline = deadline
            };

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            return Ok(submission);
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
