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

            foreach (UIState.ResourceToWorkerGaugeMap workerGaugeMap in uiState.WorkerGauges)
            {
                ResourceState resourceState = gameState.Resources[workerGaugeMap.ResourceType];
                workerGaugeMap.WorkerGauge.SetCount(resourceState.AssignedWorkers);
            }

            foreach (UIState.ResourceToWorkerControlMap workerControlMap in uiState.WorkerControls)
            {
                ResourceState resourceState = gameState.Resources[workerControlMap.ResourceType];
                workerControlMap.WorkerControl.Gauge.SetCount(resourceState.AssignedWorkers);
            }


            uiState.UnemploymentGauge.SetCount(gameState.Resources.UnassignedWorkers);
        }
    }
}
