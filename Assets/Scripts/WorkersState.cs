using System;
using System.Collections.Generic;

namespace GodsExperiment
{
    public class WorkersState
    {
        public bool IsFoodEnabled { get; set; }
        public float DailyWorkerFoodCost { get; set; }
        public float NewWorkerFoodCost { get; set; }
        public float TotalDailyFoodCost => DailyWorkerFoodCost * GetTotalWorkers();
        public bool IsUnderfed { get; set; }
        public float UnderfedProductivityPenalty { get; set; } = 0;
        public float Productivity => 1 - UnderfedProductivityPenalty;

        private readonly Dictionary<ResourceType, int> _workerAllocations = new();

        public WorkersState(int initialWorkers, bool isFoodEnabled)
        {
            IsFoodEnabled = isFoodEnabled;
            foreach (ResourceType resourceType in (ResourceType[]) Enum.GetValues(typeof(ResourceType)))
                _workerAllocations.Add(
                    key: resourceType,
                    value: resourceType == ResourceType.None ? initialWorkers : 0
                );
        }

        public int this[ResourceType resourceType]
        {
            get => _workerAllocations[resourceType];
            set => _workerAllocations[resourceType] = value;
        }

        public int GetTotalWorkers()
        {
            var workerCount = 0;
            foreach (int allocatedWorkers in _workerAllocations.Values)
                workerCount += allocatedWorkers;

            return workerCount;
        }
    }
}
