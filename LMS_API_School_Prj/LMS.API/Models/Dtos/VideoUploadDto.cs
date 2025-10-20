public class VideoUploadDto
{
    public string ModuleId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public IFormFile File { get; set; } = default!;
    public string? VideoUrl { get; internal set; }
}
