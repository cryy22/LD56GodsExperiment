using System.Collections.Generic;

namespace GodsExperiment
{
    public class ResourceState
    {
        public readonly Dictionary<ResourceType, float> ResourceCosts = new();

        public ResourceType Type { get; private set; }
        public int WorkerSlots { get; set; } = 1;

        public float WorkUnitsAdded
        {
            get => _workUnitsAdded;
            set
            {
                if (value > _workUnitsAdded)
                    TotalWorkUnits += value - _workUnitsAdded;

                _workUnitsAdded = value;
            }
        }

        public float WorkUnitsPerUnit { get; set; }
        public bool IsPaid { get; set; }

        public float Count
        {
            get => _count;
            set
            {
                if (value > _count)
                {
                    JustIncreasedBy += value - _count;
                    TotalCreated += value - _count;
                }
                else
                {
                    JustDecreasedBy += _count - value;
                }

                _count = value;
            }
        }

        public float JustIncreasedBy { get; private set; }
        public float JustDecreasedBy { get; private set; }
        public float TotalCreated { get; private set; }

        public float TotalWorkUnits { get; private set; }

        public float Progress => WorkUnitsAdded / WorkUnitsPerUnit;

        private float _count;
        private float _workUnitsAdded;

        public ResourceState(ResourceRequirementSet resourceRequirementSet)
        {
            Type = resourceRequirementSet.ResourceType;
            Count = 0;
            WorkUnitsPerUnit = resourceRequirementSet.WorkUnits;

            foreach (ResourceQuantity resourceQuantity in resourceRequirementSet.RequiredResources)
                ResourceCosts[resourceQuantity.Resource] = resourceQuantity.Quantity;
        }

        public void AdjustValue(float amount) { _count += amount; }

        public void ResetJustChangedByValues()
        {
            JustIncreasedBy = 0;
            JustDecreasedBy = 0;
        }
    }
}
