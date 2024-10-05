namespace GodsExperiment
{
    public class UISystem
    {
        public void Update(GameState gameState, UIState uiState)
        {
            foreach (UIState.ResourceToResourceGaugeMap resourceMap in uiState.ResourceGauges)
            {
                ResourceState resourceState = gameState.Resources[resourceMap.ResourceType];
                resourceMap.ResourceGauge.SetValues(count: resourceState.Count, progress: resourceState.Progress);
            }

            foreach (UIState.ResourceToWorkerGaugeMap workerMap in uiState.WorkerGauges)
            {
                ResourceState resourceState = gameState.Resources[workerMap.ResourceType];
                workerMap.WorkerGauge.SetCount(resourceState.AssignedWorkers);
            }

            uiState.UnemploymentGauge.SetCount(gameState.Resources.UnassignedWorkers);
        }
    }
}
