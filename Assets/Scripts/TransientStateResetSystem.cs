namespace GodsExperiment
{
    public class TransientStateResetSystem
    {
        public void Update(GameState state)
        {
            state.Input.PausePressed = false;
            state.Input.PlayPressed = false;
            state.Input.FastForwardPressed = false;
            state.Input.VeryFastForwardPressed = false;

            state.Input.WorkerAddPressed = ResourceType.None;
            state.Input.WorkerRemovePressed = ResourceType.None;
            state.Input.WorkerChangeMassModifier = false;

            state.Input.ConstructionRequested = ResourceType.None;
            state.Input.ConstructionChangeMassModifier = false;

            state.Time.DayChanged = false;

            foreach (ResourceType resourceType in state.Resources.ResourceTypes)
                state.Resources[resourceType].ResetJustChangedByValues();
        }
    }
}
