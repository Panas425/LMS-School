import { ReactElement, useContext, useEffect, useState } from "react";
import { ApiDataContext } from "../context/ApiDataProvider";

import "../css/UserListPage.css";

import { RenderUserListPage } from "./render/RenderUserList";
import { ICourses, IUser, IUserCourse } from "../utils";


export function UserListPage(): ReactElement {
  const { getCourseById, userCourses, fetchUsers, handleDeleteUser, fetchUsersWithCourses,courses,fetchAllCourses } = useContext(ApiDataContext);

  const [course, setCourses] = useState<ICourses[]>([]);
  const [users, setUsers] = useState<IUser[]>([]);

  
  useEffect(() => {
    const fetchData = async () => {
      const fetchedCourses = await fetchAllCourses(); // Fetch courses here
      const fetchedUsers = await fetchUsers(); // Fetch users here
      setUsers(fetchedUsers);
    };

    fetchData();
  }, []); // Empty dependency array means this runs once on mount

  
  
  return <>
  <RenderUserListPage users={users} course={courses} deleteUser={handleDeleteUser}/>
  </>;
}
