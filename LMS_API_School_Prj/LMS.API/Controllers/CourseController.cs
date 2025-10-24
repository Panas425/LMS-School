using AutoMapper;
using LMS.API.Data;
using LMS.API.Models.Dtos;
using LMS.API.Models.Entities;
using LMS.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ServiceManager _serviceManager;
        public CourseController(IMapper mapper, DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            //_serviceManager = serviceManager;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            try
            {
                var courses = await _context.Courses.Include(c => c.Modules).ToListAsync();
                var courseDtos = _mapper.Map<List<CourseDto>>(courses);

                return Ok(courseDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse([FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var course = _mapper.Map<Course>(courseDto);
                _context.Set<Course>().Add(course);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<CourseDto>(course);

                return CreatedAtAction(nameof(CreateCourse), new { id = result.id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [Authorize(Roles = "Teacher,Student")]
        [HttpGet("{user_id}/courses")]
        public async Task<ActionResult<UserCoursesDto>> GetUserCourses(string user_id)
        {
            var user = await _context.Users
                .Include(u => u.CourseUsers)
                .ThenInclude(cu => cu.Course)
                .ThenInclude(c => c.Modules)
                .FirstOrDefaultAsync(u => u.Id == user_id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (!user.CourseUsers.Any())
            {
                return NotFound("User is not assigned to any courses.");
            }

            var dto = new UserCoursesDto
            {
                UserName = user.UserName ?? string.Empty,
                Courses = user.CourseUsers
                    .Select(cu => _mapper.Map<CourseDto>(cu.Course))
                    .ToList()
            };

            return Ok(dto);
        }


        [Authorize(Roles = "Teacher")]
        [HttpGet("getCourseById/{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(string id)
        {
            var course = await _context.Courses
                .Include(c => c.Modules)
                .FirstOrDefaultAsync(c => c.Id.ToString() == id);

            if (course == null)
            {
                return NotFound("User not found.");
            }

            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _context.Set<Course>()
                .Include(c => c.Modules)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> UpdateCourse(string id, CourseForUpdateDto courseDto)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == id);
            if (course == null)
            {
                return NotFound();
            }
            _mapper.Map(courseDto, course);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<CourseForUpdateDto>(course));

        }

        [HttpGet("usercourses")]
        public async Task<ActionResult<IEnumerable<UserCourseDto>>> GetUsersWithCourses()
        {
            try
            {
                var users = await _context.Users
                    .Include(u => u.CourseUsers)
                    .ThenInclude(cu => cu.Course)
                    .ToListAsync();

                var userCourseDtos = users.Select(user => new UserCourseDto
                {
                    UserName = user.UserName ?? string.Empty,
                    Courses = user.CourseUsers.Any()
                        ? user.CourseUsers.Select(cu => cu.Course.Name).ToList()
                        : new List<string> { "No Course Assigned" }
                }).ToList();

                return Ok(userCourseDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching users and courses.");
            }
        }

        [HttpGet("{courseId}/students")]
        public async Task<ActionResult<List<AttendanceDto>>> GetStudentsByCourse(Guid courseId)
        {
            var students = await _context.CourseUsers
                .Where(cu => cu.CourseId == courseId && cu.RoleInCourse == "Student")
                .Include(cu => cu.User)
                .Select(cu => new AttendanceDto
                {
                    StudentId = cu.UserId, // ändrat här
                    CourseId = cu.CourseId,
                    FirstName = cu.User.FirstName,
                    LastName = cu.User.LastName,
                    Date = DateTime.UtcNow
                }).ToListAsync();

            return Ok(students);
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("{courseId}/attendance")]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAttendanceRecords(Guid courseId)
        {
            // Hämta attendance inklusive studenten (ApplicationUser) för att få namn
            var attendanceRecords = await _context.Attendances
                .Where(a => a.CourseId == courseId)
                .Include(a => a.Student)  // Navigeringsproperty till ApplicationUser, t.ex. "Student"
                .ToListAsync();

            // Mappa till DTO inkluderande namn
            var attendanceDtos = attendanceRecords.Select(a => new AttendanceDto
            {
                CourseId = a.CourseId,
                StudentId = a.StudentId,
                FirstName = a.Student?.FirstName,
                LastName = a.Student?.LastName,
                Date = a.Date,
                IsPresent = a.IsPresent
            }).ToList();

            return Ok(attendanceDtos);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("{courseId}/attendance")]
        public async Task<ActionResult> SaveAttendance(Guid courseId, [FromBody] List<AttendanceDto> attendanceList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var date = attendanceList.FirstOrDefault()?.Date.Date ?? DateTime.Today;

            foreach (var dto in attendanceList)
            {
                var existing = await _context.Attendances
                    .FirstOrDefaultAsync(a => a.CourseId == courseId
                                           && a.StudentId == dto.StudentId
                                           && a.Date.Date == dto.Date.Date);

                if (existing != null)
                {
                    existing.IsPresent = dto.IsPresent;
                }
                else
                {
                    _context.Attendances.Add(new Attendance
                    {
                        CourseId = courseId,
                        StudentId = dto.StudentId,
                        Date = dto.Date,
                        IsPresent = dto.IsPresent
                    });
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();

        }










    }
}
