using System;
using UnityEngine;

namespace GodsExperiment
{
    public class FoodSystem
    {
        public void Update(TimeState time, ResourceState food, WorkersState workers)
        {
            if (!time.DayChanged)
                return;

            float foodPayable = Mathf.Min(a: workers.TotalDailyFoodCost, b: food.Count);
            food.Count -= foodPayable;

            if (food.Count >= workers.NewWorkerFoodCost)
            {
                int newWorkers = Mathf.FloorToInt(food.Count / workers.NewWorkerFoodCost);
                workers[ResourceType.None] += newWorkers;
                food.Count -= workers.NewWorkerFoodCost * newWorkers;
            }
            else if (foodPayable >= workers.TotalDailyFoodCost - Mathf.Epsilon)
            {
                workers.IsUnderfed = false;
                workers.UnderfedProductivityPenalty = 0;
            }
            else if (workers.IsUnderfed == false) // weren't underfed yesterday
            {
                workers.IsUnderfed = true;
                workers.UnderfedProductivityPenalty = -food.Count / workers.TotalDailyFoodCost;
                food.Count = 0;
            }
            else // consecutively underfed workers leave
            {
                workers.IsUnderfed = false;
                workers.UnderfedProductivityPenalty = 0;

                int unfedWorkers = Mathf.CeilToInt(-food.Count / workers.DailyWorkerFoodCost);
                food.Count = 0;

                if (unfedWorkers >= workers.GetTotalWorkers())
                    unfedWorkers = workers.GetTotalWorkers() - 1;

                unfedWorkers = DismissUnfedWorkers(
                    unfedWorkers: unfedWorkers,
                    workers: workers,
                    resourceType: ResourceType.None
                );

                foreach (ResourceType resourceType in (ResourceType[]) Enum.GetValues(typeof(ResourceType)))
                {
                    if (resourceType == ResourceType.None) continue;
                    unfedWorkers = DismissUnfedWorkers(
                        unfedWorkers: unfedWorkers,
                        workers: workers,
                        resourceType: resourceType
                    );

                    if (unfedWorkers == 0) break;
                }
            }
        }

        private static int DismissUnfedWorkers(int unfedWorkers, WorkersState workers, ResourceType resourceType)
        {
            int availableWorkers = workers[resourceType];
            workers[resourceType] -= Mathf.Min(a: availableWorkers, b: unfedWorkers);
            int workersDismissed = availableWorkers - workers[resourceType];

            return unfedWorkers - workersDismissed;
        }
    }
}
