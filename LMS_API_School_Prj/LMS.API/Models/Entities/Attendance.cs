namespace LMS.API.Models.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string? StudentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public Course? Course { get; set; }
        public ApplicationUser? Student { get; set; }
    }

}
