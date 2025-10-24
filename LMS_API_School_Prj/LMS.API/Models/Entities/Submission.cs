using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.API.Models.Entities
{
    public class Submission
    {
        public Guid Id { get; set; }

        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public string FileUrl { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        // Koppling till elev
        [Required]
        public string StudentId { get; set; } = string.Empty;
        public ApplicationUser? Student { get; set; }

        // Koppling till aktivitet
        [Required]
        public Guid ActivityId { get; set; }
        public Activity? Activity { get; set; }

        // Status
        public DateTime? Deadline { get; set; }
        public bool IsLate => Deadline.HasValue && SubmittedAt > Deadline.Value;

        public string? StudentName { get; set; }
    }
}
