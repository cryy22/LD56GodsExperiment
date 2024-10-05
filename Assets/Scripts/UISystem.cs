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
                workerGauge.SetCount(gameState.Workers[resourceType]);

            uiState.UnemploymentGauge.SetCount(gameState.Workers[ResourceType.None]);
            uiState.DayProgressBar.SetProgress(gameState.Time.DayProgress);
            if (gameState.Time.DayChanged)
                uiState.CurrentDayCount.text = $"day {(gameState.Time.Day + 1).ToString()}";
        }
    }
}
