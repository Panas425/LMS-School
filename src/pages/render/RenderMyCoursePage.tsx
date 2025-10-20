import { ReactElement, useContext, useEffect, useState } from "react";
import { LogoutBtn } from "../../components/LogoutBtn";
import { ModuleCard } from "../../components/ModuleCard";
import "../../css/MyCoursePage.css";
import { ApiDataContext } from "../../context/ApiDataProvider";

export function RenderMyCoursePage(): ReactElement {
  const { user, myCourses, fetchCoursesForUser } = useContext(ApiDataContext);
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
      <p className="student-identity">{"Hi, " + user.name}</p>

      {/* Container for all courses */}
      <div className="course-grid">
        {myCourses.map((course) => (
          <div key={course.id} className="course-card">
            <p className="title">{course.name}</p>

            <section className="module-section">
              {course.modules && course.modules.length > 0 ? (
                <div className="module-grid">
                  {course.modules.map((module) => (
                    <div key={module.id} className="module-card">
                      <ModuleCard module={module} />
                    </div>
                  ))}
                </div>
              ) : (
                <p>No modules available for this course.</p>
              )}
            </section>
          </div>
        ))}
      </div>

      <LogoutBtn />
    </main>

  );
}
