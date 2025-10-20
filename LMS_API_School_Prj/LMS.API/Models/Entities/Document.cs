using LMS.API.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum DocumentType
{
    File,
    Video
}

[Table("Document")]
public class Document
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string FileName { get; set; } = string.Empty;

    [Required]
    public string FileUrl { get; set; } = string.Empty;

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public string UploadedById { get; set; } = string.Empty;
    public ApplicationUser? UploadedBy { get; set; }

    // Nytt fält
    public DocumentType Type { get; set; } = DocumentType.File;

    public Guid? CourseId { get; set; }
    public Course? Course { get; set; }

    public Guid? ModuleId { get; set; }
    public Module? Module { get; set; }

    public Guid? ActivityId { get; set; }
    public Activity? Activity { get; set; }
}
