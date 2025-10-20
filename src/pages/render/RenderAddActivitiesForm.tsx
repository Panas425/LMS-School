import { ReactElement, useContext, useState } from "react";
import { Modal, Button, Form, Spinner } from "react-bootstrap";
import { ApiDataContext } from "../../context/ApiDataProvider";

interface RenderAddActivitiesFormProps {
  show: boolean;
  handleClose: () => void;
  moduleID: string;
  onSuccess: () => void;
  handleSubmit: (moduleID: string) => Promise<void>;
}

export function RenderAddActivitiesForm({
  show,
  handleClose,
  moduleID,
  onSuccess,
  handleSubmit,
}: RenderAddActivitiesFormProps): ReactElement {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [activityType, setActivityType] = useState("");
  const [start, setStart] = useState("");
  const [end, setEnd] = useState("");

  // New states for submission
  const [file, setFile] = useState<File | null>(null);
  const [deadline, setDeadline] = useState("");
  const [isSubmitting, setIsSubmitting] = useState(false);

  const { createActivity, uploadSubmission } = useContext(ApiDataContext);

  const handleFormSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    setIsSubmitting(true);
    try {
      // Step 1️⃣: Create the activity
      const activityDetails = {
        name,
        description,
        activityType,
        start,
        end,
        moduleID,
      };

      const newActivity = await createActivity(activityDetails);

      // Step 2️⃣: If user uploaded a file, post submission
      if (file && newActivity?.id) {
        await uploadSubmission({
          file,
          activityId: newActivity.id,
          deadline: deadline ? new Date(deadline) : null,
        });
      }

      // Step 3️⃣: Refresh activities and reset
      await handleSubmit(moduleID);
      onSuccess();
      handleClose();

      // Reset fields
      setName("");
      setDescription("");
      setActivityType("");
      setStart("");
      setEnd("");
      setFile(null);
      setDeadline("");
    } catch (error) {
      console.error("Error creating activity or uploading submission:", error);
      alert("Failed to create activity or upload submission.");
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <Modal show={show} onHide={handleClose} backdrop="static">
      <Modal.Header closeButton>
        <Modal.Title>Add Activity & Optional Submission</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form onSubmit={handleFormSubmit}>
          <Form.Group controlId="formField1">
            <Form.Label>Activity Name</Form.Label>
            <Form.Control
              type="text"
              placeholder="Enter activity name"
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
            />
          </Form.Group>

          <Form.Group controlId="formField2" className="mt-3">
            <Form.Label>Description</Form.Label>
            <Form.Control
              as="textarea"
              rows={3}
              placeholder="Enter description"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
            />
          </Form.Group>

          <Form.Group controlId="formField3" className="mt-3">
            <Form.Label>Activity Type</Form.Label>
            <Form.Control
              type="text"
              placeholder="Enter activity type"
              value={activityType}
              onChange={(e) => setActivityType(e.target.value)}
            />
          </Form.Group>

          <Form.Group controlId="formField4" className="mt-3">
            <Form.Label>Start Date</Form.Label>
            <Form.Control
              type="date"
              value={start}
              onChange={(e) => setStart(e.target.value)}
            />
          </Form.Group>

          <Form.Group controlId="formField5" className="mt-3">
            <Form.Label>End Date</Form.Label>
            <Form.Control
              type="date"
              value={end}
              onChange={(e) => setEnd(e.target.value)}
            />
          </Form.Group>

          <Modal.Footer className="mt-4">
            <Button variant="secondary" onClick={handleClose} disabled={isSubmitting}>
              Close
            </Button>
            <Button variant="primary" type="submit" disabled={isSubmitting}>
              {isSubmitting ? (
                <>
                  <Spinner animation="border" size="sm" className="me-2" />
                  Saving...
                </>
              ) : (
                "Submit"
              )}
            </Button>
          </Modal.Footer>
        </Form>
      </Modal.Body>
    </Modal>
  );
}
