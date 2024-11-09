using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace GodsExperiment
{
    public class UISystem
    {
        public UISystem(GameState state, UIState uiState)
        {
            foreach (Transform child in uiState.LeftIndustryResourceControlParent)
                Object.Destroy(child.gameObject);
            foreach (Transform child in uiState.CenterIndustryResourceControlParent)
                Object.Destroy(child.gameObject);

            uiState.FeedingSector.gameObject.SetActive(state.Workers.IsFoodEnabled);
            uiState.FeedingSectorNewWorkerIndicator.SetActive(state.Workers.NewWorkerFoodCost > 0);
            uiState.ConstructionSector.gameObject.SetActive(state.Construction.IsEnabled);

            List<ResourceType> industryResources = new();
            foreach (ResourceRequirementSet requirementSet in state.Config.ResourceRequirementSets)
            {
                if (requirementSet.ResourceType == ResourceType.None) continue;
                if (requirementSet.ResourceType == ResourceType.Food) continue;
                if (requirementSet.ResourceType == ResourceType.Construction) continue;

                industryResources.Add(requirementSet.ResourceType);
            }

            if (industryResources.Count <= 3)
            {
                uiState.CenterColumn.gameObject.SetActive(false);
                uiState.LeftColumn.SetSizeWithCurrentAnchors(
                    axis: RectTransform.Axis.Horizontal,
                    size: uiState.ColumnWidthLarge
                );
                uiState.FeedingSector.SetParent(uiState.LeftColumnContent);
            }
            else
            {
                uiState.CenterColumn.gameObject.SetActive(true);
                uiState.LeftColumn.SetSizeWithCurrentAnchors(
                    axis: RectTransform.Axis.Horizontal,
                    size: uiState.ColumnWidthSmall
                );
                uiState.FeedingSector.SetParent(uiState.CenterColumnContent);
            }

            uiState.FeedingSector.SetAsLastSibling();
            for (var i = 0; i < industryResources.Count; i++)
            {
                ResourceType resourceType = industryResources[i];
                ResourceControl control = Object.Instantiate(
                    original: uiState.ResourceControlPrefab,
                    parent: i < 4
                        ? uiState.LeftIndustryResourceControlParent
                        : uiState.CenterIndustryResourceControlParent
                );

                uiState.AddResourceControl(type: resourceType, control: control);
            }

            if (state.Construction.IsEnabled)
                uiState.ConstructionCostLabel.SetCost(state.Config.NewWorkerSlotResourceRequirement.RequiredResources);

            foreach ((ResourceType resourceType, List<ResourceControl> controls) in uiState.ResourcesResourceControls)
            {
                if (!state.Workers.IsFoodEnabled && (resourceType == ResourceType.Food))
                    continue;
                if (!state.Construction.IsEnabled && (resourceType == ResourceType.Construction))
                    continue;

                foreach (ResourceControl control in controls)
                    control.SetResourceCosts(state.Resources[resourceType].ResourceCosts);
            }

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
            uiState.GoalsLine.Initialize(
                state: state,
                targets: state.Config.ResourceTargets,
                totalDays: state.Config.TotalDays
            );

            uiState.NewWorkerRequirementCount.text =
                state.Workers.NewWorkerFoodCost.ToString(CultureInfo.InvariantCulture);

            uiState.HypothesisStatementIndicator.Initialize(state);

            uiState.Tooltip.SetContent(string.Empty);

            uiState.BGMPlayer.Play();
        }

        public void Update(GameState state, UIState uiState)
        {
            foreach ((ResourceType resourceType, List<ResourceControl> controls) in uiState.ResourcesResourceControls)
            {
                if (!state.Workers.IsFoodEnabled && (resourceType == ResourceType.Food))
                    continue;
                if (!state.Construction.IsEnabled && (resourceType == ResourceType.Construction))
                    continue;
                if (controls.Count == 0)
                    continue;

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
                    if (control.ResourceRequirementsSign == null)
                        Debug.Log("here!!");
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
                if (!state.Workers.IsFoodEnabled && (resourceType == ResourceType.Food))
                    continue;
                if (!state.Construction.IsEnabled && (resourceType == ResourceType.Construction))
                    continue;

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
                if (!state.Workers.IsFoodEnabled && (resourceType == ResourceType.Food))
                    continue;
                if (!state.Construction.IsEnabled && (resourceType == ResourceType.Construction))
                    continue;

                workerGauge.SetSlots(count: state.Resources[resourceType].WorkerSlots, resourceType: resourceType);
                workerGauge.SetWorkers(state.Workers[resourceType]);
            }

            uiState.UnemploymentGauge.SetSlots(count: state.Workers.GetTotalWorkers(), resourceType: ResourceType.None);
            uiState.UnemploymentGauge.SetWorkers(state.Workers[ResourceType.None]);

            if (state.Workers.IsFoodEnabled)
            {
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
            }

            if (state.Construction.IsEnabled)
            {
                uiState.ConstructionQueueGauge.SetConstructionQueue(state.Construction.Queue);
                uiState.ConstructionQueueControl.SetControlsInteractabilities(
                    resources: state.Resources,
                    config: state.Config
                );
            }

            uiState.DayProgressBar.SetProgress(state.Time.DayProgress);
            uiState.PausedIndicator.SetActive(state.Time.IsTimePaused);
            uiState.Tooltip.SetContent(state.Input.IsTooltipEnabled ? state.Input.TooltipContent : string.Empty);

            uiState.BGMPlayer.SetFilterMode(
                state.Time.IsTimePaused
                    ? BGMPlayer.AudioFilterMode.LowPassed
                    : BGMPlayer.AudioFilterMode.Unfiltered
            );
        }
    }
}
