namespace GodsExperiment
{
    public class WorkerAssignmentSystem
    {
        public void Update(WorkersState workers, ResourcesState resources, InputState input)
        {
            if (input.WorkerAddPressed != ResourceType.None)
            {
                ResourceType resourceType = input.WorkerAddPressed;
                if ((workers[ResourceType.None] > 0) && (workers[resourceType] < resources[resourceType].WorkerSlots))
                {
                    workers[resourceType] += 1;
                    workers[ResourceType.None] -= 1;
                }
            }

            if (input.WorkerRemovePressed != ResourceType.None)
            {
                ResourceType resourceType = input.WorkerAddPressed;
                if (workers[resourceType] > 0)
                {
                    workers[resourceType] -= 1;
                    workers[ResourceType.None] += 1;
                }
            }
        }
    }
}
