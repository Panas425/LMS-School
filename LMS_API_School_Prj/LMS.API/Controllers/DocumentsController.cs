using LMS.API.Data;
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
    public class DocumentsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DocumentsController(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/documents?courseId=...&moduleId=...&activityId=...
        [HttpGet]
        public async Task<IActionResult> GetDocuments([FromQuery] Guid? courseId, [FromQuery] Guid? moduleId, [FromQuery] Guid? activityId)
        {
            var query = _context.Documents.AsQueryable();

            if (courseId.HasValue)
                query = query.Where(d => d.CourseId == courseId);

            if (moduleId.HasValue)
                query = query.Where(d => d.ModuleId == moduleId);

            if (activityId.HasValue)
                query = query.Where(d => d.ActivityId == activityId);

            var documents = await query.ToListAsync();
            return Ok(documents);
        }

        // POST: api/documents/upload
        [HttpPost("upload")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> UploadDocument([FromForm] IFormFile file, [FromForm] Guid? courseId, [FromForm] Guid? moduleId, [FromForm] Guid? activityId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Save file locally or upload to Azure Blob (this example = local)
            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var filePath = Path.Combine(uploadsPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new Document
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FileUrl = filePath,
                UploadedAt = DateTime.UtcNow,
                UploadedById = User?.Identity?.Name ?? "Unknown",
                CourseId = courseId,
                ModuleId = moduleId,
                ActivityId = activityId
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocuments), new { id = document.Id }, document);
        }

        [HttpPost("upload-video")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> UploadVideo([FromForm] VideoUploadDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("No file uploaded.");

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!_context.Modules.Any(m => m.Id == Guid.Parse(dto.ModuleId)))
                return BadRequest("Module not found.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedVideos");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(dto.File.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await dto.File.CopyToAsync(stream);

            var video = new Document
            {
                Id = Guid.NewGuid(),
                FileName = dto.Title ?? dto.File.FileName,
                FileUrl = $"/UploadedVideos/{uniqueFileName}",
                Type = DocumentType.Video,
                UploadedAt = DateTime.UtcNow,
                UploadedById = user.Id,
                ModuleId = Guid.Parse(dto.ModuleId)
            };

            _context.Documents.Add(video);
            await _context.SaveChangesAsync();

            return Ok(video);
        }



    }
}
