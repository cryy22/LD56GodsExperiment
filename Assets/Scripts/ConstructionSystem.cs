namespace GodsExperiment
{
    public class ConstructionSystem
    {
        public void Update(ConstructionState construction, ResourcesState resources, WorkersState workers)
        {
            if (construction.Queue.Count == 0)
            {
                WorkerAssigner.UnassignAllWorkers(
                    workers: workers,
                    resources: resources,
                    resourceType: ResourceType.Construction
                );
                resources[ResourceType.Construction].Count = 0;
                resources[ResourceType.Construction].WorkUnitsAdded = 0;
            }
            else if (resources[ResourceType.Construction].Count > 0)
            {
                ResourceType newSlotResource = construction.Queue[0];
                resources[newSlotResource].WorkerSlots++;

                construction.Queue.RemoveAt(0);
                resources[ResourceType.Construction].Count = 0;
            }
        }
    }
}
