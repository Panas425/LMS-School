using LMS.API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LMS.API.Models.Dtos
{
    public class ActivityListDto
    {
        public Guid Id { get; set; }   
        [Required] public string? Name { get; set; }
        [Required] public string? Description { get; set; }
        [Required] public string? ActivityType { get; set; }
        [Required] public DateTime? Start { get; set; }
        [Required] public DateTime? End { get; set; }
        [Required] public Guid ModuleId { get; set; }
    }
}
