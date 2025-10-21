import { ReactElement, useContext } from "react";
import { ApiDataContext } from "../context/ApiDataProvider";
import { IModules } from "../utils";
import { ModuleDetails } from "./ModuleDetails";
import { ModuleActions } from "./ModuleActions";
import { ModuleModal } from "./ModuleModal";
import { RenderAddActivitiesForm } from "../pages/render/RenderAddActivitiesForm";
import { useModuleData } from "../hooks/useModuleData";

interface IModuleProps {
  module?: IModules;
}

export function ModuleCard({ module }: IModuleProps): ReactElement {
  const { fetchActivities, fetchModuleVideos, deleteModule, user } = useContext(ApiDataContext);

  const {
    activitiesList,
    videosWithFullUrl,
    showModal,
    showFormModal,
    showVideoModal,
    formatDate,
    setShowModal,
    handleUploadSuccess,
    onActivityBtnClick,
    handleActivitySuccess,
    handleOpenFormModal,
    handleCloseFormModal,
    handleCloseVideoModal,
    handleSubmitForm,
    handleRemoveModule
  } = useModuleData(module?.id, fetchActivities, fetchModuleVideos, deleteModule);

  return (
    <span>
      <div className="card-src">
        <ModuleDetails module={module!} formatDate={formatDate} />
        <ModuleActions
          onActivityClick={() => onActivityBtnClick(module!.id)}
          onDeleteClick={() => handleRemoveModule(module!.id)}
        />
      </div>

      <ModuleModal
        show={showModal}
        onClose={() => setShowModal(false)}
        module={module!}
        activitiesList={activitiesList}
        videos={videosWithFullUrl}
        user={user!}
        handleOpenForm={handleOpenFormModal}
        showVideoModal={showVideoModal}
        handleCloseVideoModal={handleCloseVideoModal}
        handleUploadSuccess={handleUploadSuccess}
        handleActivitySuccess={handleActivitySuccess}
      />

      <RenderAddActivitiesForm
        show={showFormModal}
        handleClose={handleCloseFormModal}
        handleSubmit={handleSubmitForm}
        moduleID={module!.id}
        onSuccess={handleActivitySuccess}
      />
    </span>
  );
}
