namespace GodsExperiment
{
    public class ResourceState
    {
        public float Count { get; set; }
        public float WorkUnitsAdded { get; set; }
        public bool IsPaid { get; set; }

        public float WorkUnitsPerUnit { get; set; }
        public float BooitePerUnit { get; set; }
        public float BooiumPerUnit { get; set; }
        public float BoosPerUnit { get; set; }

        public float Progress => WorkUnitsAdded / WorkUnitsPerUnit;

        public ResourceState(ResourceRequirements resourceRequirements)
        {
            Count = 0;
            WorkUnitsPerUnit = resourceRequirements.WorkUnits;
            BooitePerUnit = resourceRequirements.Booite;
            BooiumPerUnit = resourceRequirements.Booium;
            BoosPerUnit = resourceRequirements.Boos;
        }
    }
}
