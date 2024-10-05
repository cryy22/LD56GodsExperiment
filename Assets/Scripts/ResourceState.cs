namespace GodsExperiment
{
    public class ResourceState
    {
        public int BooiteCount = 0;
        public float WorkUnitsAddedToBooite = 0f;
        public float WorkUnitsPerBooite = 999f;
        
        public float BooiteProgress => WorkUnitsAddedToBooite / WorkUnitsPerBooite;
    }
}
