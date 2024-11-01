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

            if (food.Count >= workers.TotalDailyFoodCost)
            {
                food.Count -= workers.TotalDailyFoodCost;
                workers.IsUnderfed = false;
                workers.UnderfedProductivityPenalty = 0;

                int newWorkers = Mathf.FloorToInt(food.Count / workers.NewWorkerFoodCost);
                food.Count -= workers.NewWorkerFoodCost * newWorkers;
                workers[ResourceType.None] += newWorkers;
            }
            else
            {
                float foodDeficit = workers.TotalDailyFoodCost - food.Count;
                food.Count = 0;

                // workers were not underfed yesterday
                if (workers.IsUnderfed == false)
                {
                    workers.IsUnderfed = true;
                    workers.UnderfedProductivityPenalty = foodDeficit / workers.TotalDailyFoodCost * 0.5f;
                }
                // workers were consecutively underfed; attrition
                else
                {
                    workers.IsUnderfed = false;
                    workers.UnderfedProductivityPenalty = 0;

                    int unfedWorkers = Mathf.CeilToInt(foodDeficit / workers.DailyWorkerFoodCost);
                    unfedWorkers = Mathf.Min(a: unfedWorkers, b: workers.GetTotalWorkers() - 1);

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
