using UnityEngine;

namespace GodsExperiment
{
    public static class ResourceForecaster
    {
        public static bool WillMeetFoodDemand(WorkersState workers, ResourcesState resources, TimeState time)
        {
            if (workers.TotalDailyFoodCost <= resources[ResourceType.Food].Count) return true;
            return workers.TotalDailyFoodCost <= ForecastResourceCount(
                resourceType: ResourceType.Food,
                workers: workers,
                resources: resources,
                time: time
            );
        }

        public static float ForecastResourceCount(
            ResourceType resourceType,
            WorkersState workers,
            ResourcesState resources,
            TimeState time
        )
        {
            ResourceState resource = resources[resourceType];

            float count = resource.Count;
            float workUnitsRemaining =
                (time.TimePerDay - time.Time) * workers[resourceType] * workers.Productivity;

            float maxWorkable = Mathf.Floor(workUnitsRemaining / resource.WorkUnitsPerUnit);
            if (resource.ResourceCosts.Count == 0)
                return count + maxWorkable; // no haircut required; no construction inefficiencies possible

            float maxAffordable = Mathf.Infinity;
            foreach ((ResourceType requiredResource, float cost) in resource.ResourceCosts)
            {
                float affordableCount = Mathf.Floor(
                    ForecastResourceCount(
                        resourceType: requiredResource,
                        workers: workers,
                        resources: resources,
                        time: time
                    ) / cost
                );
                if (affordableCount < maxAffordable) maxAffordable = affordableCount;
            }

            float maxConstructible = Mathf.Min(a: maxWorkable, b: maxAffordable);
            // -1 haircut is just a cheap way of accounting for construction inefficiencies (e.g. waiting on a reagent)
            return count + Mathf.Max(a: 0, b: maxConstructible - 1);
        }
    }
}
