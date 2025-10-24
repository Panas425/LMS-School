namespace LMS.API.Models.Dtos
{
    public class AttendanceDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid CourseId { get; set; }
        public string? StudentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }

}
