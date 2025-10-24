using LMS.API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LMS.API.Models.Dtos
{
    public record UserForListDto 
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        public List<Guid> CourseIDs { get; set; } = new List<Guid>();

    }
}
