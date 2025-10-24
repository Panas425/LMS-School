import { useNavigate } from "react-router-dom";
import { CourseCard } from "../../components";
import { useApiContext } from "../../hooks/useApiDataContext";
import { useEffect } from "react";

export function RenderCourseList() {
  const {
    courses,
    setCourse,
    fetchAllCourses,
    fetchUsersWithCourses,
    deleteCourse,
  } = useApiContext();
  const navigate = useNavigate();

  const handleClick = (course: any) => {
    setCourse(course);
    navigate(`/coursedetails/${course.id}`);
  };

  useEffect(() => {
    fetchAllCourses();
    fetchUsersWithCourses();
  }, []);

  return (
    <div className="container my-5">
      <h1 className="mb-4 text-center text-primary">Course List</h1>

      {courses && courses.length > 0 ? (
        <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
          {courses.map((course) => (
            <div key={course.id} className="col">
              <div
                className="card h-100 shadow-sm border-0 hover-shadow cursor-pointer"
                onClick={() => handleClick(course)}
              >
                <CourseCard course={course} handleCourseDelete={deleteCourse} />
              </div>
            </div>
          ))}
        </div>
      ) : (
        <div className="alert alert-info text-center">
          No courses available.
        </div>
      )}
    </div>
  );
}
