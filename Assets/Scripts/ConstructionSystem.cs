namespace GodsExperiment
{
    public class ConstructionSystem
    {
        public void Update(
            ConstructionState construction,
            ResourcesState resources,
            InputState input,
            GameConfig config
        )
        {
            if (!construction.IsEnabled)
                return;

            if (input.ConstructionQueueClearRequested)
            {
                for (var i = 0; i < construction.Queue.Count; i++)
                    ResourcePaymentProcessor.RefundPayment(
                        resourceCosts: construction.ResourceCosts,
                        resources: resources
                    );

                construction.Queue.Clear();
            }

            if (input.ConstructionRequested != ResourceType.None)
            {
                int constructionsCount = input.ConstructionChangeMassModifier ? 5 : 1;
                for (var i = 0; i < constructionsCount; i++)
                    if (resources[input.ConstructionRequested].WorkerSlots < config.MaxWorkersPerResource)
                    {
                        bool isPaid = ResourcePaymentProcessor.AttemptPayment(
                            resourceCosts: construction.ResourceCosts,
                            resources: resources
                        );
                        if (isPaid)
                            construction.Queue.Add(input.ConstructionRequested);
                    }
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
