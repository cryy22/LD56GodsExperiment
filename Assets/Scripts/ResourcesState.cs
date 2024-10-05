namespace GodsExperiment
{
    public class ResourcesState
    {
        public ResourceState Booite { get; private set; }
        public ResourceState Booium { get; private set; }

        public ResourcesState(ResourceRequirements booiteRequirements, ResourceRequirements booiumRequirements)
        {
            Booite = new ResourceState(booiteRequirements);
            Booium = new ResourceState(booiumRequirements);
        }
    }
}
