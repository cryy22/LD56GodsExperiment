using System.Collections.Generic;

namespace GodsExperiment
{
    public class ResourcesState
    {
        public float UnworkedResourcesDecayRate { get; set; }

        public IEnumerable<ResourceType> ResourceTypes => _resourceStates.Keys;
        private readonly Dictionary<ResourceType, ResourceState> _resourceStates = new();

        public ResourcesState(
            ResourceRequirementSet[] requirementSets,
            GameConfig.ResourceWorkerSlotsSet[] resourceWorkerSlotsSets
        )
        {
            foreach (ResourceRequirementSet resourceRequirements in requirementSets)
                _resourceStates[resourceRequirements.ResourceType] = new ResourceState(resourceRequirements);

            foreach (GameConfig.ResourceWorkerSlotsSet resourceWorkerSlots in resourceWorkerSlotsSets)
                _resourceStates[resourceWorkerSlots.ResourceType].WorkerSlots = resourceWorkerSlots.WorkerSlots;
        }

        public ResourceState this[ResourceType resourceType] => _resourceStates[resourceType];
    }
}
