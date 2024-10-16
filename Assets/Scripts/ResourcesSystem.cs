using UnityEngine;

namespace GodsExperiment
{
    public class ResourcesSystem
    {
        public void Update(ResourcesState resources, WorkersState workers, TimeState time)
        {
            if (time.IsTimePaused)
                return;
            foreach (ResourceType resourceType in resources.ResourceTypes)
                UpdateResource(
                    resourceType: resourceType,
                    resources: resources,
                    workers: workers,
                    deltaTime: time.DeltaTime
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
                if (workers[resourceType] <= 0) return;
                resource.IsPaid = ResourcePaymentProcessor.AttemptPayment(
                    resourceCosts: resource.ResourceCosts,
                    resources: resources
                );
            }

            if (!resource.IsPaid) return;

            if (workers[resourceType] > 0)
                resource.WorkUnitsAdded +=
                    workers[resourceType] * workers.Productivity * deltaTime;
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
