import { ReactElement, useContext, useEffect, useState } from "react";
import { ApiDataContext } from "../../context/ApiDataProvider";

export function AddUserForm(): ReactElement {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");
  const [role, setRole] = useState("");
  const [courseid, setCourseId] = useState("");
  const [error, setError] = useState<string | null>(null);
  const { courses, createUser } = useContext(ApiDataContext);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    // Basic validation
    if (!username || !password || !email || !role) {
      setError("All fields are required!");
      return;
    }

    const userData = {
      UserName: username,
      Password: password,
      Email: email,
      Role: role,
      CourseIDs: courseid ? courseid.split(",") : [],
    };

    try {
      await createUser(userData);
      alert("User data registered successfully");

      setError(null); // Clear error on successful submission

    } catch (err) {
      setError("Error creating user, please try again.");
      console.error("Error creating user:", err);
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        {error && <div className="alert alert-danger">{error}</div>}

        <div className="form-group">
          <label htmlFor="formGroupExampleInput">User Name</label>
          <input
            type="text"
            className="form-control"
            id="formGroupExampleInput"
            placeholder="User Name"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>

        <div className="form-group">
          <label htmlFor="InputPassword">Password</label>
          <input
            type="password"
            className="form-control"
            id="InputPassword"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <div className="form-group">
          <label htmlFor="emailinput">Email address</label>
          <input
            className="form-control"
            type="email"
            id="emailinput"
            placeholder="name@example.com"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="form-group">
          <label htmlFor="inputState">Role</label>
          <select
            id="inputState"
            className="form-control"
            value={role}
            onChange={(e) => setRole(e.target.value)}
          >
            <option value="">Role...</option>
            <option value="Teacher">Teacher</option>
            <option value="Student">Student</option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="inputCourses">Courses</label>
          <select
            id="inputCourses"
            className="form-control"
            multiple   // 👈 allow multiple selection
            value={courseid ? courseid.split(",") : []}
            onChange={(e) => {
              const selectedCourses = Array.from(e.target.selectedOptions, option => option.value);
              setCourseId(selectedCourses.join(",")); // store as comma-separated string
              console.log("Selected Course IDs:", selectedCourses);
            }}
          >
            {courses?.map((course) => (
              <option key={course.id} value={course.id}>
                {course.name}
              </option>
            ))}
          </select>
        </div>

        {/*courseid && (
  <div>
    <p>Selected Course ID: {courseid}</p>
  </div>
)*/}

        <button type="submit" className="btn btn-primary">
          Add User
        </button>
      </form>
    </>
  );
}
