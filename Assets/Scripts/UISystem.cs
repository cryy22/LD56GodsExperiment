using System.Collections.Generic;
using System.Globalization;

namespace GodsExperiment
{
    public class UISystem
    {
        public UISystem(GameState state, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceGauge> gauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge gauge in gauges)
            {
                gauge.ShowCountText(
                    resourceType switch
                    {
                        ResourceType.Construction => false,
                        _                         => true,
                    }
                );

                gauge.SetIcon(state.Config.GetSpriteForResource(resourceType));
                gauge.SetColor(state.Config.GetColorForResource(resourceType));
            }

            foreach ((ResourceType resourceType, List<WorkerControl> controls) in uiState.ResourcesWorkerControls)
            foreach (WorkerControl control in controls)
                control.ResourceType = resourceType;

            uiState.UnderfedProductivityPenaltyCountLabel.SetActive(false);

            uiState.ConstructionQueueControl.SetAvailableResources(
                resourceTypes: state.Config.ResourcesAvailableForConstruction,
                config: state.Config
            );

            uiState.ConversionTable.SetResourceCosts(resources: state.Resources, config: state.Config);
            uiState.TotalDaysCount.text = $"of {state.Config.TotalDays}";
            uiState.TotalBoosCount.text = $"of {state.Config.TotalBoosTarget}";
        }

        public void Update(GameState state, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceGauge> resourceGauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge resourceGauge in resourceGauges)
            {
                ResourceState resourceState = state.Resources[resourceType];
                resourceGauge.SetValues(count: resourceState.Count, progress: resourceState.Progress);

                if (resourceType == ResourceType.Construction)
                    resourceGauge.SetIcon(state.Config.GetSpriteForResource(state.Construction.InProgress));
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

            uiState.ConstructionQueueGauge.SetConstructionQueue(
                queuedResourceTypes: state.Construction.Queue,
                config: state.Config
            );
            uiState.ConstructionQueueControl.SetControlsInteractabilities(
                resources: state.Resources,
                config: state.Config
            );

            uiState.DayProgressBar.SetProgress(state.Time.DayProgress);

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
            uiState.CurrentBoosCount.text = $"{((int) state.Resources[ResourceType.Boos].Count).ToString()}";
        }
    }
}
