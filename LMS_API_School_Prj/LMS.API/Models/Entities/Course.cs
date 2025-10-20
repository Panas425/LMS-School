using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS.API.Models.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        // Initialize non-nullable string properties
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Start { get; set; }

        // Optional End property
        public DateTime? End { get; set; }

        // Use ICollection<T> for EF Core navigation properties
        public ICollection<Module> Modules { get; set; } = new List<Module>();

        // Optional navigation for many-to-many users
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        // Many-to-many join table
        public ICollection<CourseUser> CourseUsers { get; set; } = new List<CourseUser>();

        public ICollection<Document> Documents { get; set; } = new List<Document>();

    }
}

