interface ModuleActionsProps {
    onActivityClick: () => void;
    onDeleteClick: () => void;
}

export function ModuleActions({ onActivityClick, onDeleteClick }: ModuleActionsProps) {
    return (
        <div className="btn-container">
            <button className="btn-layout" onClick={onActivityClick}>
                Activities
            </button>
            <button className="btn-layout" onClick={onDeleteClick}>
                Delete
            </button>
        </div>
    );
}
