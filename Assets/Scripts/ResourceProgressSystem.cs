namespace GodsExperiment
{
    public class ResourceProgressSystem
    {
        public void Update(ResourcesState state, TimeState timeState)
        {
            UpdateResource(state: state.Booite, resourcesState: state, deltaTime: timeState.DeltaTime);
            UpdateResource(state: state.Booium, resourcesState: state, deltaTime: timeState.DeltaTime);
            UpdateResource(state: state.Boos, resourcesState: state, deltaTime: timeState.DeltaTime);
        }

        private static void UpdateResource(ResourceState state, ResourcesState resourcesState, float deltaTime)
        {
            if (!state.IsPaid)
            {
                bool isResourceAffordable =
                    (state.BooitePerUnit <= resourcesState.Booite.Count) &&
                    (state.BooiumPerUnit <= resourcesState.Booium.Count) &&
                    (state.BoosPerUnit <= resourcesState.Boos.Count);

                if (isResourceAffordable)
                {
                    resourcesState.Booite.Count -= state.BooitePerUnit;
                    resourcesState.Booium.Count -= state.BooiumPerUnit;
                    resourcesState.Boos.Count -= state.BoosPerUnit;
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
