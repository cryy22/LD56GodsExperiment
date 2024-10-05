namespace GodsExperiment
{
    public class ResourceProgressSystem
    {
        public void Update(ResourcesState state, TimeState timeState)
        {
            foreach (ResourceType resource in state.ResourceTypes)
                UpdateResource(state: state[resource], resourcesState: state, deltaTime: timeState.DeltaTime);
        }

        private static void UpdateResource(ResourceState state, ResourcesState resourcesState, float deltaTime)
        {
            if (!state.IsPaid)
            {
                var isResourceAffordable = true;
                foreach ((ResourceType requiredResource, float cost) in state.ResourceCosts)
                    if (cost > resourcesState[requiredResource].Count)
                    {
                        isResourceAffordable = false;
                        break;
                    }

                if (isResourceAffordable && (state.AssignedWorkers > 0))
                {
                    foreach ((ResourceType requiredResource, float cost) in state.ResourceCosts)
                        resourcesState[requiredResource].Count -= cost;

                    state.IsPaid = true;
                }
                else
                {
                    return;
                }
            }

            state.WorkUnitsAdded += deltaTime * state.AssignedWorkers;
            if (state.WorkUnitsAdded >= state.WorkUnitsPerUnit)
            {
                state.Count += 1;
                state.WorkUnitsAdded = 0;
                state.IsPaid = false;
            }
        }
    }
}
