using LMS.API.Models.Dtos;
using LMS.API.Models.Dtos.Mapper;

public class SubmissionDto
{
    public string Id { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public ActivityDto Activity { get; set; }
    public StudentDto Student { get; set; }
}