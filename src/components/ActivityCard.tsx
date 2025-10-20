import { useState, useEffect, useContext } from "react";
import { ApiDataContext } from "../context/ApiDataProvider";
import { Button, Form, ListGroup, Spinner } from "react-bootstrap";
import { IActivity, ISubmission } from "../utils";

interface IActivityCardProps {
  activity: IActivity;
}

export function ActivityCard({ activity }: IActivityCardProps) {
  const { uploadSubmission, fetchSubmissionsByActivity, user, deleteSubmission, fetchMySubmissionForActivity } = useContext(ApiDataContext);
  const [submissions, setSubmissions] = useState<ISubmission[]>([]);
  const [file, setFile] = useState<File | null>(null);
  const [loading, setLoading] = useState(false);
  const [uploading, setUploading] = useState(false);

  const isTeacher = user?.role === "teacher";
  const isStudent = user?.role === "student";

  // Load submissions for this activity and user role
  useEffect(() => {
    if (!activity?.id || !user?.id) return;

    setLoading(true);
    if (isTeacher) {
      fetchSubmissionsByActivity(activity.id)
        .then((data) => setSubmissions(data))
        .finally(() => setLoading(false));
    } else if (isStudent) {
      fetchMySubmissionForActivity(user.id)
        .then((data) => {
          // Filter by current activity if backend does not filter
          const filtered = data.filter(sub => sub.activity?.id === activity.id);
          setSubmissions(filtered);
        })
        .finally(() => setLoading(false));
    }
  }, [activity?.id, user?.id, isTeacher, isStudent, fetchSubmissionsByActivity, fetchMySubmissionForActivity]);

  const handleUpload = async (userId: string) => {
    if (!file) return alert("Select a file first");
    setUploading(true);
    try {
      await uploadSubmission({ file, activityId: activity.id });
      alert("Upload successful!");
      const updated = await fetchMySubmissionForActivity(userId);
      const filtered = updated.filter(sub => sub.activity?.id === activity.id);
      setSubmissions(filtered);
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
        const filtered = updated.filter(sub => sub.activity?.id === activity.id);
        setSubmissions(filtered);
      }
    } catch (err) {
      console.error(err);
      alert("Failed to remove submission");
    }
  };

  const studentSubmission = submissions[0] || null; // Assumes one submission per student per activity

  return (
    <div>
      <h5>{activity.name}</h5>
      <p>{activity.description}</p>

      {/* Teacher view: show submissions */}
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
                  {sub.student?.userName} -{" "}
                  <a
                    href={`http://localhost:5058/UploadedSubmissions/${sub.fileName}`}
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

      {/* Student view: upload submission */}
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
                onClick={() => handleUpload(user!.id)}
                disabled={uploading || !file}
              >
                {uploading ? "Uploading..." : "Upload"}
              </Button>
            </div>
          ) : (
            <div>
              <p>
                You have already submitted:{" "}
                <a
                  href={`http://localhost:5058/UploadedSubmissions/${studentSubmission.fileName}`}
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
