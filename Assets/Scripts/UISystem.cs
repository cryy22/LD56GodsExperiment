using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace GodsExperiment
{
    public class UISystem
    {
        public UISystem(GameState state, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceControl> controls) in uiState.ResourcesResourceControls)
            foreach (ResourceControl control in controls)
                control.SetResourceCosts(state.Resources[resourceType].ResourceCosts);

            foreach ((ResourceType resourceType, List<ResourceGauge> gauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge gauge in gauges)
            {
                gauge.ShowCountText(resourceType != ResourceType.Construction);
                gauge.SetIcon(ResourceDefinitionIndex.I.GetSpriteForResource(resourceType));
                gauge.SetColor(ResourceDefinitionIndex.I.GetColorForResource(resourceType));
            }

            foreach ((ResourceType resourceType, List<WorkerControl> controls) in uiState.ResourcesWorkerControls)
            foreach (WorkerControl control in controls)
                control.ResourceType = resourceType;

            uiState.ConstructionQueueControl.SetAvailableResources(state.Config.ResourcesAvailableForConstruction);

            uiState.ConversionTable.SetResourceCosts(resources: state.Resources, config: state.Config);
            uiState.TotalDaysCount.text = $"of {state.Config.TotalDays}";
            // TODO: replace this with multiple labels showing all resource targets
            uiState.TotalBoosCount.text = $"of {state.Config.ResourceTargets[0].TargetAmount}";

            uiState.NewWorkerRequirementCount.text =
                state.Workers.NewWorkerFoodCost.ToString(CultureInfo.InvariantCulture);

            uiState.Tooltip.SetContent(string.Empty);
        }

        public void Update(GameState state, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceControl> controls) in uiState.ResourcesResourceControls)
            {
                if (controls.Count == 0) continue;
                ResourceState resourceState = state.Resources[resourceType];
                foreach (ResourceControl control in controls)
                {
                    control.WorkerCountText.text = state.Workers[resourceType].ToString();
                    float rateOfProduction = RateOfProductionCalculator.CalculatePerDay(
                        workers: state.Workers,
                        resource: resourceState,
                        time: state.Time
                    );
                    control.RateOfProductionText.text = $"({rateOfProduction:F1}/day)";
                    control.ResourceRequirementsSign.SetActive(
                        !resourceState.IsPaid
                        && (resourceState.ResourceCosts.Count > 0)
                        && Mathf.Approximately(a: resourceState.JustIncreasedBy, b: 0)
                        && (state.Workers[resourceType] > 0)
                    );
                }
            }

            foreach ((ResourceType resourceType, List<ResourceGauge> resourceGauges) in uiState.ResourcesResourceGauges)
            foreach (ResourceGauge resourceGauge in resourceGauges)
            {
                ResourceState resourceState = state.Resources[resourceType];
                resourceGauge.SetValues(count: resourceState.Count, progress: resourceState.Progress);

                if (resourceType == ResourceType.Construction)
                    resourceGauge.SetIcon(
                        ResourceDefinitionIndex.I.GetSpriteForResource(state.Construction.InProgress)
                    );
            }

            foreach ((ResourceType resourceType, List<WorkerGauge> workerGauges) in uiState.ResourcesWorkerGauges)
            foreach (WorkerGauge workerGauge in workerGauges)
            {
                workerGauge.SetSlots(count: state.Resources[resourceType].WorkerSlots, resourceType: resourceType);
                workerGauge.SetWorkers(state.Workers[resourceType]);
            }

            uiState.UnemploymentGauge.SetSlots(count: state.Workers.GetTotalWorkers(), resourceType: ResourceType.None);
            uiState.UnemploymentGauge.SetWorkers(state.Workers[ResourceType.None]);

            uiState.WorkerFoodRequirementCount.text = $"{(int) state.Workers.TotalDailyFoodCost}";
            if (state.Workers.TotalDailyFoodCost <= state.Resources[ResourceType.Food].Count)
            {
                uiState.WorkerFoodRequirementCount.color = Constants.Green;
            }
            else
            {
                bool willMeetFoodDemand = FoodForecaster.WillMeetDemand(
                    workers: state.Workers,
                    resources: state.Resources,
                    time: state.Time
                );
                uiState.WorkerFoodRequirementCount.color = willMeetFoodDemand ? Constants.Black : Constants.Red;
            }

            uiState.UnderfedProductivityPenaltyCount.text = $"{state.Workers.Productivity * 100:F1}%";
            uiState.UnderfedProductivityPenaltyCount.color =
                state.Workers.Productivity < 1 ? Constants.Red : Constants.Black;

            uiState.ConstructionQueueGauge.SetConstructionQueue(state.Construction.Queue);
            uiState.ConstructionQueueControl.SetControlsInteractabilities(
                resources: state.Resources,
                config: state.Config
            );

            uiState.DayProgressBar.SetProgress(state.Time.DayProgress);

            uiState.CurrentDayCount.text = $"day {(state.Time.Day + 1).ToString()}";
            uiState.CurrentBoosCount.text = $"{((int) state.Resources[ResourceType.Boos].Count).ToString()}";

            uiState.Tooltip.SetContent(state.Input.IsTooltipEnabled ? state.Input.TooltipContent : string.Empty);
        }
    }
}
