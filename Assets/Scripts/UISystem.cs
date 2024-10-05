namespace GodsExperiment
{
    public class UISystem
    {
        public void Update(GameState gameState, UIState uiState)
        {
            UpdateResourceGauge(state: gameState.ResourcesState.Booite, gauge: uiState.BooiteGauge);
            UpdateResourceGauge(state: gameState.ResourcesState.Booium, gauge: uiState.BooiumGauge);
            UpdateResourceGauge(state: gameState.ResourcesState.Boos, gauge: uiState.BoosGauge);
        }

        private void UpdateResourceGauge(ResourceState state, ResourceGauge gauge)
        {
            gauge.SetValues(count: state.Count, progress: state.Progress);
        }
    }
}
