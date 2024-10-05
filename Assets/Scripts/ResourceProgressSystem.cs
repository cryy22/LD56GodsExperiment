namespace GodsExperiment
{
    public class ResourceProgressSystem
    {
        public void Update(ResourcesState state, TimeState timeState)
        {
            UpdateResource(state.Booite, state, timeState.DeltaTime);
            UpdateResource(state.Booium, state, timeState.DeltaTime);
        }

        private static void UpdateResource(ResourceState state, ResourcesState resourcesState, float deltaTime)
        {
            if (!state.IsPaid)
            {
                var isResourceAffordable =
                    (state.BooitePerUnit <= resourcesState.Booite.Count) &&
                    (state.BooiumPerUnit <= resourcesState.Booium.Count);

                if (isResourceAffordable)
                {
                    resourcesState.Booite.Count -= state.BooitePerUnit;
                    resourcesState.Booium.Count -= state.BooiumPerUnit;
                    state.IsPaid = true;
                }
                else
                {
                    return;
                }
            }
            
            state.WorkUnitsAdded += deltaTime;
            if (state.WorkUnitsAdded >= state.WorkUnitsPerUnit)
            {
                state.Count += 1;
                state.WorkUnitsAdded = 0;
                state.IsPaid = false;
            }
        }
    }
}
