namespace GodsExperiment
{
    public class ConstructionSystem
    {
        public void Update(
            ConstructionState construction,
            ResourcesState resources,
            WorkersState workers,
            InputState input
        )
        {
            if (input.ConstructionRequested != ResourceType.None)
            {
                bool isPaid = ResourcePaymentProcessor.AttemptPayment(
                    resourceCosts: construction.ResourceCosts,
                    resources: resources
                );
                if (isPaid)
                    construction.Queue.Add(input.ConstructionRequested);

                input.ConstructionRequested = ResourceType.None;
            }

            if (construction.InProgress == ResourceType.None)
            {
                if (construction.Queue.Count > 0)
                {
                    construction.InProgress = construction.Queue[0];
                    construction.Queue.RemoveAt(0);
                }
                else
                {
                    WorkerAssigner.UnassignAllWorkers(
                        workers: workers,
                        resources: resources,
                        resourceType: ResourceType.Construction
                    );
                    resources[ResourceType.Construction].Count = 0;
                    resources[ResourceType.Construction].WorkUnitsAdded = 0;
                }
            }
            else if (resources[ResourceType.Construction].Count > 0)
            {
                resources[construction.InProgress].WorkerSlots++;
                construction.InProgress = ResourceType.None;
                resources[ResourceType.Construction].Count = 0;
            }
        }
    }
}
