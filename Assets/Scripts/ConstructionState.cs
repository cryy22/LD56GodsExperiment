using System.Collections.Generic;

namespace GodsExperiment
{
    public class ConstructionState
    {
        public readonly Dictionary<ResourceType, float> ResourceCosts = new();
        public readonly List<ResourceType> Queue = new();
        public ResourceType InProgress { get; set; }

        public ConstructionState(ResourceRequirementSet resourceRequirementSet)
        {
            InProgress = ResourceType.None;

            foreach (ResourceQuantity resourceQuantity in resourceRequirementSet.RequiredResources)
                ResourceCosts[resourceQuantity.Resource] = resourceQuantity.Quantity;
        }
    }
}
