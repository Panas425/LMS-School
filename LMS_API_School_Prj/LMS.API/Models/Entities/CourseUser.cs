namespace LMS.API.Models.Entities
{
    public class CourseUser
    {
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;

        // Optional: role within the course (e.g. "Student" vs "Teacher")
        public string RoleInCourse { get; set; } = "Student";
    }

}
