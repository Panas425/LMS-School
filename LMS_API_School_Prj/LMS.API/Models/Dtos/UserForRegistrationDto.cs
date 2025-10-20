using LMS.API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LMS.API.Models.Dtos;

public record UserForRegistrationDto
{
    [Required] public string? FirstName { get; set; }
    [Required] public string? LastName { get; set; }
    public string? UserName { get; set; }      // optional, server-generated
    public string? Password { get; set; }      // optional, server-generated
    [Required, EmailAddress] public string? Email { get; init; }
    [Required] public string? Role { get; init; }
    public List<string>? CourseIDs { get; set; } = new();
}

