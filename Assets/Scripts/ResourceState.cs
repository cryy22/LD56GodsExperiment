using System.Collections.Generic;

namespace GodsExperiment
{
    public class ResourceState
    {
        public readonly Dictionary<ResourceType, float> ResourceCosts = new();

        public float Count { get; set; }
        public float WorkUnitsAdded { get; set; }
        public float WorkUnitsPerUnit { get; set; }
        public bool IsPaid { get; set; }

        public float Progress => WorkUnitsAdded / WorkUnitsPerUnit;

        public ResourceState(ResourceRequirementSet resourceRequirementSet)
        {
            Count = 0;
            WorkUnitsPerUnit = resourceRequirementSet.WorkUnits;

            foreach (ResourceQuantity resourceQuantity in resourceRequirementSet.RequiredResources)
                ResourceCosts[resourceQuantity.Resource] = resourceQuantity.Quantity;
        }
    }
}
