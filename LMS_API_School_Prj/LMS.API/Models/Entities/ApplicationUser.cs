﻿using Microsoft.AspNetCore.Identity;

namespace LMS.API.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
    public ICollection<CourseUser> CourseUsers { get; set; } = new List<CourseUser>();

}
