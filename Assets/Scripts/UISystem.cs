namespace GodsExperiment
{
    public class UISystem
    {
        public void Update(GameState gameState, UIState uiState)
        {
            UpdateResourceGauge(gameState.ResourcesState.Booite, uiState.BooiteGauge);
            UpdateResourceGauge(gameState.ResourcesState.Booium, uiState.BooiumGauge);
        }

        private void UpdateResourceGauge(ResourceState state, ResourceGauge gauge)
        {
            gauge.SetValues(state.Count, state.Progress);
        }
    }
}
