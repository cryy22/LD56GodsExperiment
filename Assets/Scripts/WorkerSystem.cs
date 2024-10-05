namespace GodsExperiment
{
    public class WorkerSystem
    {
        public void Update(ResourcesState resources, InputState input)
        {
            if (input.WorkerAddPressed != ResourceType.None)
            {
                ResourceState resource = resources[input.WorkerAddPressed];
                if ((resources.UnassignedWorkers > 0) && (resource.AssignedWorkers < Constants.MaxWorkersPerResource))
                {
                    resource.AssignedWorkers += 1;
                    resources.UnassignedWorkers -= 1;
                }
            }

            if (input.WorkerRemovePressed != ResourceType.None)
            {
                ResourceState resource = resources[input.WorkerRemovePressed];
                if (resource.AssignedWorkers > 0)
                {
                    resource.AssignedWorkers -= 1;
                    resources.UnassignedWorkers += 1;
                }
            }
        }
    }
}
