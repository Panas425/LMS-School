import { ReactElement, useContext, useEffect, useState } from "react";
import { ICourses, IUser, IUserLoggedIn } from "../../utils";
import { LogoutBtn } from "../../components/LogoutBtn";
import { ModuleCard } from "../../components/ModuleCard";
import { StudentCard } from "../../components/StudentCard";
import "../../css/MyCoursePage.css";
import { ApiDataContext } from "../../context/ApiDataProvider";

export function RenderMyCoursePage(): ReactElement {
  const { user, myCourses, userList, fetchCoursesForUser } = useContext(ApiDataContext);
  const [hasFetchedData, setHasFetchedData] = useState(false);

  // Fetch courses when user is available
  useEffect(() => {
    if (!user || hasFetchedData) return;

    const fetchData = async () => {
      try {
        await fetchCoursesForUser(user.id);
      } catch (err) {
        console.error("Error fetching courses:", err);
      } finally {
        setHasFetchedData(true);
      }
    };

    fetchData();
  }, [user, hasFetchedData, fetchCoursesForUser]);

  if (!user) return <p>Loading user...</p>;
  if (!myCourses || myCourses.length === 0) return <p>Loading courses...</p>;

  return (
    <main className="home-section">
      {/* User info */}
      <p className="student-identity">{user.name}</p>

      {/* Courses and Modules */}
      {myCourses.map((course) => (
        <section key={course.id} className="course-section">
          <p className="title">{course.name}</p>

          <section className="module-section">
            <div className="container">
              <div className="row">
                {course.modules && course.modules.length > 0 ? (
                  course.modules.map((module) => (
                    <div key={module.id} className="module-card">
                      <ModuleCard module={module} />
                    </div>
                  ))
                ) : (
                  <p>No modules available for this course.</p>
                )}
              </div>
            </div>
          </section>
        </section>
      ))}

      {/* Students Section */}
      <section className="students-section">
        <p className="sub-tit">Students</p>
        {userList && userList.length > 0 ? (
          userList.map((student) => (
            <div key={student.id} className="col-12 mb-3">
              <StudentCard
                student={{
                  userName: student.userName,
                  email: student.email,
                }}
              />
            </div>
          ))
        ) : (
          <p>No students available.</p>
        )}
      </section>

      {/* Logout Button */}
      <LogoutBtn />
    </main>
  );
}
