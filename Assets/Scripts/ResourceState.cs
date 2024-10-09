using System.Collections.Generic;

namespace GodsExperiment
{
    public class ResourceState
    {
        public readonly Dictionary<ResourceType, float> ResourceCosts = new();

        public ResourceType Type { get; private set; }
        public float Count { get; set; }
        public int WorkerSlots { get; set; } = 1;
        public float WorkUnitsAdded { get; set; }
        public float WorkUnitsPerUnit { get; set; }
        public bool IsPaid { get; set; }

        public float Progress => WorkUnitsAdded / WorkUnitsPerUnit;

        public ResourceState(ResourceRequirementSet resourceRequirementSet)
        {
            Type = resourceRequirementSet.ResourceType;
            Count = 0;
            WorkUnitsPerUnit = resourceRequirementSet.WorkUnits;

            foreach (ResourceQuantity resourceQuantity in resourceRequirementSet.RequiredResources)
                ResourceCosts[resourceQuantity.Resource] = resourceQuantity.Quantity;
        }
    }
}
