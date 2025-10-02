namespace LMS.API.Models.Dtos
{
    public class UserCoursesDto
    {
        public string UserName { get; set; } = string.Empty;
        public List<CourseDto> Courses { get; set; } = new();
    }
}
