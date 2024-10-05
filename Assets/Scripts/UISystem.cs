using System.Collections.Generic;

namespace GodsExperiment
{
    public class UISystem
    {
        public UISystem(GameConfig config, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceGauge> gauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge gauge in gauges)
            {
                gauge.SetName(config.GetNameForResource(resourceType));
                gauge.SetColor(config.GetColorForResource(resourceType));
            }
        }

        public void Update(GameState gameState, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceGauge> resourceGauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge resourceGauge in resourceGauges)
            {
                ResourceState resourceState = gameState.Resources[resourceType];
                resourceGauge.SetValues(count: resourceState.Count, progress: resourceState.Progress);
            }

            foreach ((ResourceType resourceType, List<WorkerGauge> workerGauges) in uiState.ResourcesWorkerGauges)
            foreach (WorkerGauge workerGauge in workerGauges)
            {
                ResourceState resourceState = gameState.Resources[resourceType];
                workerGauge.SetCount(resourceState.AssignedWorkers);
            }

            uiState.UnemploymentGauge.SetCount(gameState.Resources.UnassignedWorkers);
        }
    }
}
