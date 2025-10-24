import { ReactElement } from "react";
import "../css/index.css";
import { ICourses } from "../utils";

interface ICourseProps {
  course: ICourses;
  handleCourseDelete: (courseId: string) => Promise<void>;
}

export function CourseCard({
  course,
  handleCourseDelete,
}: ICourseProps): ReactElement {
  return (
    <div className="card h-100 shadow-sm border-0 course-card hover-shadow">
      <div className="card-body d-flex flex-column">
        {/* Course title */}
        <h5 className="card-title text-primary">{course.name}</h5>

        {/* Modules */}
        <h6 className="card-subtitle mb-2 text-muted">Modules</h6>
        <div className="mb-3">
          {course.modules && course.modules.length > 0 ? (
            <ul className="list-group list-group-flush">
              {course.modules.map((module) => (
                <li key={module.id} className="list-group-item p-1">
                  {module.name}
                </li>
              ))}
            </ul>
          ) : (
            <p className="text-muted small mb-0">No modules available.</p>
          )}
        </div>

        {/* Spacer to push button to bottom */}
        <div className="mt-auto d-flex justify-content-end">
          <button
            className="btn btn-danger btn-sm"
            onClick={(e) => {
              e.stopPropagation(); // prevent card click
              handleCourseDelete(course.id);
            }}
          >
            Delete
          </button>
        </div>
      </div>
    </div>
  );
}
