import { Modal, Button } from "react-bootstrap";
import { ActivityListPage } from "../pages/ActivityListPage";
import { ModuleVideos } from "./ModuleVideos";
import { UploadVideoModal } from "./UploadVideoModal";
import { IActivity, IDocument, IModules, IUserLoggedIn } from "../utils";

interface ModuleModalProps {
  show: boolean;
  onClose: () => void;
  module: IModules;
  activitiesList: IActivity[];
  videos: (IDocument & { fullUrl: string })[];
  user: IUserLoggedIn;
  handleOpenForm: () => void;
  showVideoModal: boolean;
  handleCloseVideoModal: () => void;
  handleUploadSuccess: () => void;
  handleActivitySuccess: () => void;
}

export function ModuleModal({
  show,
  onClose,
  module,
  activitiesList,
  videos,
  user,
  handleOpenForm,
  showVideoModal,
  handleCloseVideoModal,
  handleUploadSuccess,
  handleActivitySuccess,
}: ModuleModalProps) {
  return (
    <Modal show={show} onHide={onClose} backdrop={false}>
      <Modal.Header closeButton>
        <Modal.Title>{module?.name}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <ActivityListPage
          activityList={activitiesList}
          message="No activities available"
          onDeleteSuccess={handleActivitySuccess}
        />
        <ModuleVideos videos={videos} />
        {user?.role === "teacher" && (
          <>
            <Button variant="primary" onClick={handleOpenForm}>Add Activity</Button>
            <UploadVideoModal
              show={showVideoModal}
              handleClose={handleCloseVideoModal}
              moduleId={module.id}
              onUploadSuccess={handleUploadSuccess}
            />
          </>
        )}
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Close</Button>
      </Modal.Footer>
    </Modal>
  );
}
