using System.Collections.Generic;

namespace GodsExperiment
{
    public class ResourcesState
    {
        public int UnassignedWorkers { get; set; }

        public IEnumerable<ResourceType> ResourceTypes => _resourceStates.Keys;
        private readonly Dictionary<ResourceType, ResourceState> _resourceStates = new();

        public ResourcesState(int initialWorkers, ResourceRequirements[] requirements)
        {
            UnassignedWorkers = initialWorkers;
            foreach (ResourceRequirements resourceRequirements in requirements)
                _resourceStates[resourceRequirements.ResourceType] = new ResourceState(resourceRequirements);
        }

        public ResourceState this[ResourceType resourceType] => _resourceStates[resourceType];

        public int GetTotalWorkers()
        {
            int workers = UnassignedWorkers;
            foreach (ResourceState resource in _resourceStates.Values)
                workers += resource.AssignedWorkers;

            return workers;
        }
    }
}
