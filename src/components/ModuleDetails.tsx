import { IModules } from "../utils";

interface ModuleDetailsProps {
  module: IModules;
  formatDate: (dateString: string | undefined) => string;
}

export function ModuleDetails({ module, formatDate }: ModuleDetailsProps) {
  return (
    <>
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
    </>
  );
}
