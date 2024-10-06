namespace GodsExperiment
{
    public class WorkerAssignmentSystem
    {
        public void Update(WorkersState workers, ResourcesState resources, InputState input)
        {
            if (input.WorkerAddPressed != ResourceType.None)
            {
                WorkerAssigner.AssignWorker(
                    workers: workers,
                    resources: resources,
                    resourceType: input.WorkerAddPressed
                );
                input.WorkerAddPressed = ResourceType.None;
            }

            if (input.WorkerRemovePressed != ResourceType.None)
            {
                WorkerAssigner.UnassignWorker(
                    workers: workers,
                    resources: resources,
                    resourceType: input.WorkerRemovePressed
                );
                input.WorkerRemovePressed = ResourceType.None;
            }
        }
    }
}
