namespace LMS.API.Models.Dtos
{
    public class UserCourseDto
    {
        public string UserName { get; set; } = string.Empty;
        public List<string> Courses { get; set; } = new();
    }
}
