using System.Collections.Generic;

namespace GodsExperiment
{
    public class ConstructionState
    {
        public List<ResourceType> Queue { get; } = new();
        public ResourceType InProgress { get; set; } = ResourceType.None;
    }
}
