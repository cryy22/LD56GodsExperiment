using System.Collections.Generic;

namespace GodsExperiment
{
    public class ResourcesState
    {
        public float UnworkedResourcesDecayRate { get; set; }

        public IEnumerable<ResourceType> ResourceTypes => _resourceStates.Keys;
        private readonly Dictionary<ResourceType, ResourceState> _resourceStates = new();

        public ResourcesState(ResourceRequirementSet[] requirementSets)
        {
            foreach (ResourceRequirementSet resourceRequirements in requirementSets)
                _resourceStates[resourceRequirements.ResourceType] = new ResourceState(resourceRequirements);
        }

        public ResourceState this[ResourceType resourceType] => _resourceStates[resourceType];
    }
}
