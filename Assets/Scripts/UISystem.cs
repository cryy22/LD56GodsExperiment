namespace GodsExperiment
{
    public class UISystem
    {
        public void Update(GameState gameState, UIState uiState)
        {
            UpdateResourceGauge(state: gameState.ResourcesState[ResourceType.Booite], gauge: uiState.BooiteGauge);
            UpdateResourceGauge(state: gameState.ResourcesState[ResourceType.Booium], gauge: uiState.BooiumGauge);
            UpdateResourceGauge(state: gameState.ResourcesState[ResourceType.Boos], gauge: uiState.BoosGauge);
        }

        private void UpdateResourceGauge(ResourceState state, ResourceGauge gauge)
        {
            gauge.SetValues(count: state.Count, progress: state.Progress);
        }
    }
}
