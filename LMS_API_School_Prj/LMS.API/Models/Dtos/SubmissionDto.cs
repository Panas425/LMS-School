using LMS.API.Models.Dtos;
using LMS.API.Models.Dtos.Mapper;
using LMS.API.Models.Entities;

public class SubmissionDto
{
    public string Id { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public ActivityDto Activity { get; set; }
    public string StudentId { get; set; }
    public StudentDto Student { get; set; }
    public string StudentName { get; set; }
}