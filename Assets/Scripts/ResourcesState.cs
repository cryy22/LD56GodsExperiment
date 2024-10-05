using System.Collections.Generic;

namespace GodsExperiment
{
    public class ResourcesState
    {
        public IEnumerable<ResourceType> ResourceTypes => _resourceStates.Keys;
        private readonly Dictionary<ResourceType, ResourceState> _resourceStates = new();

        public ResourcesState(ResourceRequirements[] requirements)
        {
            foreach (ResourceRequirements resourceRequirements in requirements)
                _resourceStates[resourceRequirements.ResourceType] = new ResourceState(resourceRequirements);
        }

        public ResourceState this[ResourceType resourceType] => _resourceStates[resourceType];
    }
}
