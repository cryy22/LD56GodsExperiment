namespace GodsExperiment
{
    public class WorkerAssignmentSystem
    {
        public void Update(WorkersState workers, ResourcesState resources, InputState input)
        {
            if (input.WorkerAddPressed != ResourceType.None)
            {
                int workerCount = input.WorkerChangeMassModifier ? 5 : 1;
                for (var i = 0; i < workerCount; i++)
                    WorkerAssigner.AssignWorker(
                        workers: workers,
                        resources: resources,
                        resourceType: input.WorkerAddPressed
                    );

                input.WorkerAddPressed = ResourceType.None;
                input.WorkerChangeMassModifier = false;
            }

            if (input.WorkerRemovePressed != ResourceType.None)
            {
                int workerCount = input.WorkerChangeMassModifier ? 5 : 1;
                for (var i = 0; i < workerCount; i++)
                    WorkerAssigner.UnassignWorker(
                        workers: workers,
                        resources: resources,
                        resourceType: input.WorkerRemovePressed
                    );

                input.WorkerRemovePressed = ResourceType.None;
                input.WorkerChangeMassModifier = false;
            }
        }
    }
}
