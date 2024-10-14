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

                input.ConstructionRequested = ResourceType.None;
                input.ConstructionChangeMassModifier = false;
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
