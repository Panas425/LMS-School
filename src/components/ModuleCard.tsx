import { Button, Modal } from "react-bootstrap";
import { ActivityListPage } from "../pages/ActivityListPage";
import { ReactElement, useContext, useEffect, useState } from "react";
import { ApiDataContext } from "../context/ApiDataProvider";
import { RenderAddActivitiesForm } from "../pages/render/RenderAddActivitiesForm";
import { IActivity, IDocument, IModules, IVideo } from "../utils";
import { UploadVideoModal } from "./UploadVideoModal";

interface IModuleProps { module?: IModules; }

export function ModuleCard({ module }: IModuleProps): ReactElement {
  const { fetchActivities, activities, user, deleteModule, fetchModuleVideos } = useContext(ApiDataContext);
  const [activitiesList, setActivityList] = useState<IActivity[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [showFormModal, setShowFormModal] = useState(false);
  const [showVideoModal, setShowVideoModal] = useState(false);

  const backendBaseUrl = "http://localhost:5058";

  const [videos, setVideos] = useState<IDocument[]>([]);


  const formatDate = (dateString: string | undefined) => {
    if (!dateString) return "";
    return new Date(dateString).toLocaleDateString("se-SE", { year: "numeric", month: "numeric", day: "numeric" });
  };

  const handleUploadSuccess = async () => {
    const updatedVideos = await fetchModuleVideos(module!.id);
    setVideos(updatedVideos || []); // ✅ refresh UI
  };


  const onActivityBtnClick = async (moduleId: string) => {
    const moduleVideos = await fetchModuleVideos(moduleId);
    //console.log(moduleVideos[0].fileUrl);
    const fetchedActivities = await fetchActivities(moduleId);

    setActivityList(fetchedActivities || []);
    setVideos(moduleVideos || []);
    setShowModal(true);
  };


  const handleActivitySuccess = async () => {
    const refreshedActivities = await fetchActivities(module!.id);
    console.log("Refreshed activities:", refreshedActivities);
    setActivityList(refreshedActivities || []);
    console.log("Activities list state updated");
  };



  const handleOpenFormModal = () => setShowFormModal(true); const handleCloseFormModal = async () => {
    await fetchActivities(module!.id);
    setShowFormModal(false);
  };
  const handleCloseVideoModal = async () => {
    await fetchActivities(module!.id);
    setShowVideoModal(false);
  };

  const videosWithFullUrl = videos.map(video => ({
    ...video,
    fullUrl: `${backendBaseUrl}${video.fileUrl}`
  }));

  const handleSubmitForm = async (moduleID: string) => { await fetchActivities(moduleID); setActivityList(activities || []); setShowFormModal(false); };

  const handleRemoveModule = async (moduleID: string) => { await deleteModule(moduleID); window.location.reload(); }


  useEffect(() => {

    (async () => {
      const initialVideos = await fetchModuleVideos(module!.id);
      setVideos(initialVideos);
    })();
  }, [(module!.id)]);

  useEffect(() => {
    console.log("Activity list updated:", activitiesList);
  }, [activitiesList]);

  return (
    <span>
      <div className="card-src">
        <p className="title-card-src">{module?.name}</p>
        <div className="desc">
          <p className="cat-lbl">Description:</p>
          <p className="spec-lbl">{module?.description}</p>
        </div>
        <div className="desc">
          <p className="cat-lbl">Start Date:</p>
          <p className="spec-lbl">{formatDate(module?.start)}</p>
        </div>
        <div className="desc">
          <p className="cat-lbl">End Date:</p>
          <p className="spec-lbl">{formatDate(module?.end)}</p>
        </div>
        <div className="btn-container">
          <button className="btn-layout" onClick={() => onActivityBtnClick(module?.id!)}>
            Activities
          </button>
          <button className="btn-layout" onClick={() => handleRemoveModule(module?.id!)}>
            Delete
          </button>
        </div>
      </div>

      <Modal show={showModal} onHide={() => setShowModal(false)} backdrop={false}>
        <Modal.Header closeButton>
          <Modal.Title>{module?.name}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <ActivityListPage
            activityList={activitiesList}
            message="No activities available"
            onDeleteSuccess={handleActivitySuccess}  // triggers fetching and state update
          />
          {videos.length > 0 && (
            <div className="module-videos mt-3">
              <h5>Videos:</h5>
              {videosWithFullUrl.map(video => (
                <video key={video.id} width="100%" controls>
                  <source src={video.fullUrl} type="video/mp4" />
                  Your browser does not support the video tag.
                </video>
              ))}

            </div>
          )}
          {user?.role === "teacher" && (
            <>
              <Button variant="primary" onClick={handleOpenFormModal}>
                Add Activity
              </Button>
              <UploadVideoModal
                show={showVideoModal}
                handleClose={handleCloseVideoModal}
                moduleId={module?.id!}
                onUploadSuccess={handleUploadSuccess}
              />

            </>
          )}

        </Modal.Body>

        <Modal.Footer>

          <Button variant="secondary" onClick={() => setShowModal(false)}>
            Close
          </Button>
        </Modal.Footer>

      </Modal>

      <RenderAddActivitiesForm
        show={showFormModal}
        handleClose={handleCloseFormModal}
        handleSubmit={handleSubmitForm}
        moduleID={module!.id}
        onSuccess={handleActivitySuccess}
      />


    </span >
  );
}
