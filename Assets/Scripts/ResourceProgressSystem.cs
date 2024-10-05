using UnityEngine;

namespace GodsExperiment
{
    public class ResourceProgressSystem
    {
        public void Update(ResourcesState state, WorkersState workersState, TimeState timeState)
        {
            foreach (ResourceType resourceType in state.ResourceTypes)
                UpdateResource(
                    resourceType: resourceType,
                    resources: state,
                    workers: workersState,
                    deltaTime: timeState.DeltaTime
                );
        }

        private static void UpdateResource(
            ResourceType resourceType,
            ResourcesState resources,
            WorkersState workers,
            float deltaTime
        )
        {
            ResourceState resource = resources[resourceType];
            if (!resource.IsPaid)
            {
                var isResourceAffordable = true;
                foreach ((ResourceType requiredResource, float cost) in resource.ResourceCosts)
                    if (cost > resources[requiredResource].Count)
                    {
                        isResourceAffordable = false;
                        break;
                    }

                if (isResourceAffordable && (workers[resourceType] > 0))
                {
                    foreach ((ResourceType requiredResource, float cost) in resource.ResourceCosts)
                        resources[requiredResource].Count -= cost;

                    resource.IsPaid = true;
                }
                else
                {
                    return;
                }
            }

            if (workers[resourceType] > 0)
                resource.WorkUnitsAdded +=
                    workers[resourceType]
                    * (1 - workers.UnderfedProductivityPenalty)
                    * deltaTime;
            else
                resource.WorkUnitsAdded -= deltaTime * resources.UnworkedResourcesDecayRate;

            resource.WorkUnitsAdded = Mathf.Max(a: resource.WorkUnitsAdded, b: 0);

            if (resource.WorkUnitsAdded >= resource.WorkUnitsPerUnit)
            {
                resource.Count += 1;
                resource.WorkUnitsAdded = 0;
                resource.IsPaid = false;
            }
        }
    }
}
