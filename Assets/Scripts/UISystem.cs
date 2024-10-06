using System.Collections.Generic;
using System.Globalization;

namespace GodsExperiment
{
    public class UISystem
    {
        public UISystem(GameConfig config, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceGauge> gauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge gauge in gauges)
            {
                gauge.SetIcon(config.GetSpriteForResource(resourceType));
                gauge.SetColor(config.GetColorForResource(resourceType));
            }

            uiState.UnderfedProductivityPenaltyCountLabel.SetActive(false);
        }

        public void Update(GameState state, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceGauge> resourceGauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge resourceGauge in resourceGauges)
            {
                ResourceState resourceState = state.Resources[resourceType];
                resourceGauge.SetValues(count: resourceState.Count, progress: resourceState.Progress);
            }

            foreach ((ResourceType resourceType, List<WorkerGauge> workerGauges) in uiState.ResourcesWorkerGauges)
            foreach (WorkerGauge workerGauge in workerGauges)
            {
                workerGauge.SetSlots(state.Resources[resourceType].WorkerSlots);
                workerGauge.SetWorkers(state.Workers[resourceType]);
            }

            uiState.UnemploymentGauge.SetSlots(state.Workers.GetTotalWorkers());
            uiState.UnemploymentGauge.SetWorkers(state.Workers[ResourceType.None]);

            uiState.WorkerFoodRequirementCount.text =
                $"{(int) state.Workers.TotalDailyFoodCost}/day";
            uiState.NewWorkerRequirementCount.text =
                state.Workers.NewWorkerFoodCost.ToString(CultureInfo.InvariantCulture);


            uiState.DayProgressBar.SetProgress(state.Time.DayProgress);

            if (state.Time.DayChanged)
            {
                if (state.Workers.IsUnderfed)
                {
                    uiState.UnderfedProductivityPenaltyCountLabel.SetActive(true);
                    uiState.UnderfedProductivityPenaltyCount.text =
                        $"{(int) (state.Workers.UnderfedProductivityPenalty * 100)}%";
                }
                else
                {
                    uiState.UnderfedProductivityPenaltyCountLabel.SetActive(false);
                }

                uiState.CurrentDayCount.text = $"day {(state.Time.Day + 1).ToString()}";
            }
        }
    }
}
