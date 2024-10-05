using UnityEngine;

namespace GodsExperiment
{
    public class ResourceProgressSystem
    {
        public void Update(ResourcesState state, WorkersState workersState, TimeState timeState)
        {
            foreach (ResourceType resource in state.ResourceTypes)
                UpdateResource(
                    state: state[resource],
                    resourcesState: state,
                    workersCount: workersState[resource],
                    deltaTime: timeState.DeltaTime
                );
        }

        private static void UpdateResource(
            ResourceState state,
            ResourcesState resourcesState,
            int workersCount,
            float deltaTime
        )
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

                if (isResourceAffordable && (workersCount > 0))
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

            if (workersCount > 0)
                state.WorkUnitsAdded += deltaTime * workersCount;
            else
                state.WorkUnitsAdded -= deltaTime * resourcesState.UnworkedResourcesDecayRate;

            state.WorkUnitsAdded = Mathf.Max(a: state.WorkUnitsAdded, b: 0);

            if (state.WorkUnitsAdded >= state.WorkUnitsPerUnit)
            {
                state.Count += 1;
                state.WorkUnitsAdded = 0;
                state.IsPaid = false;
            }
        }
    }
}
