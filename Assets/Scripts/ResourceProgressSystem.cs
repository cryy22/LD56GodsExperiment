namespace GodsExperiment
{
    public class ResourceProgressSystem
    {
        public void Update(ResourceState state, TimeState timeState)
        {
            state.WorkUnitsAddedToBooite += timeState.DeltaTime;
            if (state.WorkUnitsAddedToBooite >= state.WorkUnitsPerBooite)
            {
                state.BooiteCount += 1;
                state.WorkUnitsAddedToBooite += state.WorkUnitsPerBooite;
            }
        }
    }
}
