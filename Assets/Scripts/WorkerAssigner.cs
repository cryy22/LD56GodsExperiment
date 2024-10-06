namespace GodsExperiment
{
    public static class WorkerAssigner
    {
        public static void AssignWorker(WorkersState workers, ResourcesState resources, ResourceType resourceType)
        {
            if ((workers[ResourceType.None] > 0) && (workers[resourceType] < resources[resourceType].WorkerSlots))
            {
                workers[resourceType] += 1;
                workers[ResourceType.None] -= 1;
            }
        }

        public static void UnassignWorker(WorkersState workers, ResourcesState resources, ResourceType resourceType)
        {
            if (workers[resourceType] > 0)
            {
                workers[resourceType] -= 1;
                workers[ResourceType.None] += 1;
            }
        }

        public static void UnassignAllWorkers(WorkersState workers, ResourcesState resources, ResourceType resourceType)
        {
            while (workers[resourceType] > 0)
                UnassignWorker(workers: workers, resources: resources, resourceType: resourceType);
        }
    }
}
