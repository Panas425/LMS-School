import { useState, useEffect } from "react";
import { IActivity, IDocument } from "../utils";

export function useModuleData(
    moduleId: string | undefined,
    fetchActivities: (moduleId: string) => Promise<IActivity[] | undefined>,
    fetchModuleVideos: (moduleId: string) => Promise<IDocument[] | undefined>,
    deleteModule: (moduleId: string) => Promise<void>
) {
    const [activitiesList, setActivityList] = useState<IActivity[]>([]);
    const [videos, setVideos] = useState<IDocument[]>([]);
    const [showModal, setShowModal] = useState(false);
    const [showFormModal, setShowFormModal] = useState(false);
    const [showVideoModal, setShowVideoModal] = useState(false);

    const backendBaseUrl = "http://localhost:5058";

    const formatDate = (dateString: string | undefined) => {
        if (!dateString) return "";
        return new Date(dateString).toLocaleDateString("se-SE", { year: "numeric", month: "numeric", day: "numeric" });
    };

    const handleUploadSuccess = async () => {
        if (!moduleId) return;
        const updatedVideos = await fetchModuleVideos(moduleId);
        setVideos(updatedVideos || []);
    };

    const onActivityBtnClick = async (moduleId: string) => {
        const moduleVideos = await fetchModuleVideos(moduleId);
        const fetchedActivities = await fetchActivities(moduleId);
        setActivityList(fetchedActivities || []);
        setVideos(moduleVideos || []);
        setShowModal(true);
    };

    const handleActivitySuccess = async () => {
        if (!moduleId) return;
        const refreshedActivities = await fetchActivities(moduleId);
        setActivityList(refreshedActivities || []);
    };

    const handleOpenFormModal = () => setShowFormModal(true);
    const handleCloseFormModal = async () => {
        if (!moduleId) return;
        await fetchActivities(moduleId);
        setShowFormModal(false);
    };

    const handleCloseVideoModal = async () => {
        if (!moduleId) return;
        await fetchActivities(moduleId);
        setShowVideoModal(false);
    };

    const videosWithFullUrl = videos.map(video => ({
        ...video,
        fullUrl: `${backendBaseUrl}${video.fileUrl}`
    }));

    const handleSubmitForm = async (moduleID: string) => {
        await fetchActivities(moduleID);
        setActivityList(await fetchActivities(moduleID) || []);
        setShowFormModal(false);
    };

    const handleRemoveModule = async (moduleID: string) => {
        await deleteModule(moduleID);
        window.location.reload();
    };

    useEffect(() => {
        if (!moduleId) return;
        (async () => {
            const initialVideos = await fetchModuleVideos(moduleId);
            setVideos(initialVideos || []);
        })();
    }, [moduleId]);

    return {
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
    };
}
