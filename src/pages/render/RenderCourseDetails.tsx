import { useEffect, useState } from "react";
import { LogoutBtn, ModuleCard, StudentCard } from "../../components";
import { Header } from "../../components/Header";
import { useApiContext } from "../../hooks/useApiDataContext";
import { useParams } from "react-router-dom";
import { Grid } from "../../components/Grid";
import { AddModuleModal } from "../../components/AddModuleModal";
import "../../css/RenderCourseDetails.css";
import { UploadVideoModal } from "../../components/UploadVideoModal";
import { IUser, IUserCourse } from "../../utils";

// ... resterande imports

export function RenderCourseDetails() {
  const { courseId } = useParams<{ courseId?: string }>();
  const {
    course,
    getCourseByIdFromRouter,
    fetchAttendanceByCourse,
    fetchUsersByCourse,
    saveAttendance,
  } = useApiContext();

  const [attendance, setAttendance] = useState<{
    [studentId: string]: boolean;
  }>({});

  const [students, setStudents] = useState<IUserCourse[]>([]);

  useEffect(() => {
    if (!courseId) return;

    (async () => {
      await getCourseByIdFromRouter([courseId]);

      const fetchedStudents = await fetchUsersByCourse(courseId);
      console.log(courseId);

      const savedAttendance = await fetchAttendanceByCourse(courseId);

      setStudents(fetchedStudents);

      const initialAttendance: { [studentId: string]: boolean } = {};
      fetchedStudents.forEach((s) => {
        const att = savedAttendance.find((a) => a.studentId === s.studentId);
        initialAttendance[s.studentId] = att ? att.isPresent : false;
      });
      setAttendance(initialAttendance);
    })();
  }, [courseId]);

  const toggleAttendance = (userId: string) => {
    setAttendance((prev) => ({
      ...prev,
      [userId]: !prev[userId],
    }));
  };

  const handleSaveAttendance = async () => {
    if (!courseId) return;

    const attendanceList = Object.entries(attendance).map(
      ([studentId, isPresent]) => ({
        studentId,
        isPresent, // This should be true/false as checked in the UI!
        courseId,
        date: new Date().toISOString(),
      })
    );
    console.log("Attendance sent:", attendanceList);

    try {
      await saveAttendance(courseId, attendanceList);
      alert("Närvarolistan sparad!");
    } catch (err) {
      console.error(err);
      alert("Fel vid sparande av närvaro: " + err);
    }
  };

  return (
    <>
      <main className="home-section">
        <Header />
        <p className="title">{course?.name}</p>

        {/* Moduler */}
        <Grid>
          <AddModuleModal />
          <div className="row">
            {course && course.modules && course.modules.length > 0 ? (
              course.modules.map((module) => (
                <div key={module.id} className="col-sm-4 mb-3">
                  <ModuleCard module={module} />
                </div>
              ))
            ) : (
              <p>No modules available.</p>
            )}
          </div>
        </Grid>

        {/* Studentlista med närvaro */}
        <Grid>
          <div>
            <p className="sub-tit">Students - Närvarolista</p>

            {students && students.length > 0 ? (
              students.map((student) => (
                <div
                  key={student.studentId}
                  className="col-12 mb-3 d-flex align-items-center"
                >
                  <StudentCard
                    student={{
                      name: student.firstName + " " + student.lastName,
                    }}
                  />

                  <input
                    type="checkbox"
                    checked={attendance[student.studentId] || false}
                    onChange={() => toggleAttendance(student.studentId)}
                    style={{ marginLeft: "auto" }}
                    aria-label={`Markera närvaro för ${student.firstName} ${student.lastName}`}
                  />
                </div>
              ))
            ) : (
              <p>No students available.</p>
            )}
            <button onClick={handleSaveAttendance}>Spara Närvarolista</button>
          </div>
        </Grid>

        <LogoutBtn />
      </main>
    </>
  );
}
