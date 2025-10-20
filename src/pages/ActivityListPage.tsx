import { ReactElement } from "react";
import { ActivityCard } from "../components/ActivityCard";
import { IActivity } from "../utils";

interface IActivityProps {
  activityList: IActivity[];
  message: string;
  onDeleteSuccess?: () => void; // added optional callback
}

export function ActivityListPage({ activityList, message }: IActivityProps): ReactElement {
  return (
    <span className="list-section">
      {activityList && activityList.length > 0 ? (
        activityList.map((act) => (
          <ActivityCard 
            key={act.id} 
            activity={act} 
          />
        ))
      ) : (
        <p>{message}</p>
      )}
    </span>
  );
}
