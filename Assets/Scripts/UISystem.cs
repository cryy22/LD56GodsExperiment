namespace GodsExperiment
{
    public class UISystem
    {
        public void Update(GameState gameState, UIState uiState)
        {
            uiState.BooiteProgressBar.SetValue(gameState.ResourceState.BooiteProgress);
            uiState.BooiteCount.text = gameState.ResourceState.BooiteCount.ToString();
        }
    }
}
