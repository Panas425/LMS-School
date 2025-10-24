import { useState, useEffect, useContext } from "react";
import { ApiDataContext } from "../context/ApiDataProvider";
import { Button, Form, ListGroup, Spinner } from "react-bootstrap";
import { IActivity, ISubmission } from "../utils";
import { useActivityStore } from "../stores/useActivityStore";

interface IActivityCardProps {
  activity: IActivity;
}

export function ActivityCard({ activity }: IActivityCardProps) {
  const {
    uploadSubmission,
    fetchSubmissionsByActivity,
    user,
    deleteSubmission,
    fetchMySubmissionForActivity,
  } = useContext(ApiDataContext);

  const submissions = useActivityStore((state) => state.submissions);
  const setSubmissions = useActivityStore((state) => state.setSubmissions);

  const [file, setFile] = useState<File | null>(null);
  const [loading, setLoading] = useState(false);
  const [uploading, setUploading] = useState(false);

  const isTeacher = user?.role === "teacher";
  const isStudent = user?.role === "student";

  // Load submissions for this activity and user role
  useEffect(() => {
    if (!activity?.id || !user?.id) return;

    setLoading(true);
    const loadSubmissions = async () => {
      try {
        if (isTeacher) {
          const data = await fetchSubmissionsByActivity(activity.id);
          setSubmissions(data);
        } else if (isStudent) {
          const data = await fetchMySubmissionForActivity(user.id);
          const filtered = data.filter(
            (sub) => sub.activity?.id === activity.id
          );
          setSubmissions(filtered);
        }
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    loadSubmissions();
  }, [
    activity?.id,
    user?.id,
    isTeacher,
    isStudent,
    fetchSubmissionsByActivity,
    fetchMySubmissionForActivity,
    setSubmissions,
  ]);

  const handleUpload = async (userId: string, studentName: string) => {
    if (!file) return alert("Select a file first");
    setUploading(true);
    try {
      await uploadSubmission({ file, studentName, activityId: activity.id });
      alert("Upload successful!");
      const updated = await fetchMySubmissionForActivity(userId);
      const filtered = updated.filter(
        (sub) => sub.activity?.id === activity.id
      );
      setSubmissions(filtered);
      setFile(null);
    } catch (err) {
      console.error(err);
      alert("Upload failed");
    } finally {
      setUploading(false);
    }
  };

  const handleRemove = async (submissionId: string) => {
    try {
      await deleteSubmission(submissionId);
      alert("Submission removed, you can upload again");
      if (isTeacher) {
        const data = await fetchSubmissionsByActivity(activity.id);
        setSubmissions(data);
      } else if (isStudent && user?.id) {
        const updated = await fetchMySubmissionForActivity(user.id);
        const filtered = updated.filter(
          (sub) => sub.activity?.id === activity.id
        );
        setSubmissions(filtered);
      }
    } catch (err) {
      console.error(err);
      alert("Failed to remove submission");
    }
  };

  // For student: pick first submission for this activity (one submission per student)
  const studentSubmission: ISubmission | null = isStudent
    ? submissions[0] || null
    : null;

  return (
    <div>
      <h5>{activity.name}</h5>
      <p>{activity.description}</p>

      {/* Teacher view */}
      {isTeacher && (
        <div>
          <h6>Submissions</h6>
          {loading ? (
            <Spinner animation="border" />
          ) : submissions.length === 0 ? (
            <p>No submissions yet</p>
          ) : (
            <ListGroup>
              {submissions.map((sub) => (
                <ListGroup.Item key={sub.id}>
                  {sub.studentName}{" "}
                  <a
                    href={`http://localhost:5058${sub.fileUrl}`}
                    target="_blank"
                    rel="noopener noreferrer"
                  >
                    {sub.fileName}
                  </a>
                </ListGroup.Item>
              ))}
            </ListGroup>
          )}
        </div>
      )}

      {/* Student view */}
      {isStudent && (
        <div>
          {!studentSubmission ? (
            <div>
              <Form.Group controlId="formFile">
                <Form.Label>Upload Submission</Form.Label>
                <Form.Control
                  type="file"
                  onChange={(e) =>
                    setFile((e.target as HTMLInputElement).files?.[0] || null)
                  }
                />
              </Form.Group>
              <Button
                onClick={() => handleUpload(user!.id, user.name)}
                disabled={uploading || !file}
                className="mt-2"
              >
                {uploading ? "Uploading..." : "Upload"}
              </Button>
            </div>
          ) : (
            <div>
              <p>
                You have already submitted:{" "}
                <a
                  href={`http://localhost:5058${studentSubmission.fileName}`}
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  {studentSubmission.fileName}
                </a>
              </p>
              <Button
                variant="danger"
                onClick={() => handleRemove(studentSubmission.id)}
              >
                Remove Submission
              </Button>
            </div>
          )}
        </div>
      )}
    </div>
  );
}
