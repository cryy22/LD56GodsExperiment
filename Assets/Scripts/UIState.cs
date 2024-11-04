using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    [DefaultExecutionOrder(-1)]
    public class UIState : MonoBehaviour
    {
        // LAYOUT CONFIGURATION
        [field: SerializeField] public RectTransform LeftColumn { get; private set; }
        [field: SerializeField] public Transform LeftColumnContent { get; private set; }
        [field: SerializeField] public RectTransform CenterColumn { get; private set; }
        [field: SerializeField] public Transform CenterColumnContent { get; private set; }
        [field: SerializeField] public float ColumnWidthLarge { get; private set; }
        [field: SerializeField] public float ColumnWidthSmall { get; private set; }
        [field: SerializeField] public Transform FeedingSector { get; private set; }
        [field: SerializeField] public Transform ConstructionSector { get; private set; }
        [field: SerializeField] public Transform LeftIndustryResourceControlParent { get; private set; }
        [field: SerializeField] public Transform CenterIndustryResourceControlParent { get; private set; }
        [field: SerializeField] public ResourceControl ResourceControlPrefab { get; private set; }

        // GAUGES AND CONTROLS
        [field: SerializeField] private ResourceToResourceControlMap[] ResourceControls { get; set; }
        [field: SerializeField] private ResourceToResourceGaugeMap[] ResourceGauges { get; set; }
        [field: SerializeField] private ResourceToWorkerControlMap[] WorkerControls { get; set; }
        [field: SerializeField] private ResourceToWorkerGaugeMap[] WorkerGauges { get; set; }

        [field: SerializeField] public WorkerGauge UnemploymentGauge { get; private set; }

        [field: SerializeField] public TMP_Text WorkerFoodRequirementCount { get; private set; }
        [field: SerializeField] public TMP_Text NewWorkerRequirementCount { get; private set; }
        [field: SerializeField] public TMP_Text UnderfedProductivityPenaltyCount { get; private set; }

        [field: SerializeField] public ConstructionQueueGauge ConstructionQueueGauge { get; private set; }
        [field: SerializeField] public ConstructionQueueControl ConstructionQueueControl { get; private set; }
        [field: SerializeField] public ConversionTable ConversionTable { get; private set; }

        [field: SerializeField] public HypothesisStatementIndicator HypothesisStatementIndicator { get; private set; }

        // COVERING CARD
        [field: SerializeField] public Transform CoveringCardTransform { get; private set; }
        [field: SerializeField] public TMP_Text CoveringCardText { get; private set; }
        [field: SerializeField] public Vector3 CoveringCardOnscreenPosition { get; private set; }
        [field: SerializeField] public Vector3 CoveringCardOffscreenPosition { get; private set; }
        [field: SerializeField] public float CoveringCardMoveDuration { get; private set; }

        // UNCATEGORIZED

        [field: SerializeField] public BGMPlayer BGMPlayer { get; private set; }
        [field: SerializeField] public ProgressBar DayProgressBar { get; private set; }
        [field: SerializeField] public GoalsLine GoalsLine { get; private set; }
        [field: SerializeField] public Tooltip Tooltip { get; private set; }
        [field: SerializeField] public NumberParticlePool NumberParticlePool { get; private set; }

        public IReadOnlyDictionary<ResourceType, List<ResourceControl>> ResourcesResourceControls =>
            _resourcesResourceControls;
        public IReadOnlyDictionary<ResourceType, List<ResourceGauge>> ResourcesResourceGauges =>
            _resourcesResourceGauges;
        public IReadOnlyDictionary<ResourceType, List<WorkerControl>> ResourcesWorkerControls =>
            _resourcesWorkerControls;
        public IReadOnlyDictionary<ResourceType, List<WorkerGauge>> ResourcesWorkerGauges =>
            _resourcesWorkerGauges;

        private readonly Dictionary<ResourceType, List<ResourceControl>> _resourcesResourceControls = new();
        private readonly Dictionary<ResourceType, List<ResourceGauge>> _resourcesResourceGauges = new();
        private readonly Dictionary<ResourceType, List<WorkerControl>> _resourcesWorkerControls = new();
        private readonly Dictionary<ResourceType, List<WorkerGauge>> _resourcesWorkerGauges = new();

        public void ResetAll()
        {
            _resourcesResourceControls.Clear();
            _resourcesResourceGauges.Clear();
            _resourcesWorkerControls.Clear();
            _resourcesWorkerGauges.Clear();

            foreach (ResourceType type in (ResourceType[]) Enum.GetValues(typeof(ResourceType)))
            {
                if (type == ResourceType.None) continue;

                _resourcesResourceControls.Add(key: type, value: new List<ResourceControl>());
                _resourcesResourceGauges.Add(key: type, value: new List<ResourceGauge>());
                _resourcesWorkerControls.Add(key: type, value: new List<WorkerControl>());
                _resourcesWorkerGauges.Add(key: type, value: new List<WorkerGauge>());
            }

            foreach (ResourceToResourceControlMap map in ResourceControls)
                AddResourceControl(type: map.ResourceType, control: map.ResourceControl);
            foreach (ResourceToResourceGaugeMap map in ResourceGauges)
                AddResourceGauge(type: map.ResourceType, gauge: map.ResourceGauge);
            foreach (ResourceToWorkerControlMap map in WorkerControls)
                AddWorkerControl(type: map.ResourceType, control: map.WorkerControl);
            foreach (ResourceToWorkerGaugeMap map in WorkerGauges)
                AddWorkerGauge(type: map.ResourceType, gauge: map.WorkerGauge);
        }

        public void AddResourceControl(ResourceType type, ResourceControl control)
        {
            _resourcesResourceControls[type].Add(control);
            AddResourceGauge(type: type, gauge: control.ResourceGauge);
            AddWorkerControl(type: type, control: control.WorkerControl);
        }

        public void AddResourceGauge(ResourceType type, ResourceGauge gauge)
        {
            _resourcesResourceGauges[type].Add(gauge);
        }

        public void AddWorkerControl(ResourceType type, WorkerControl control)
        {
            _resourcesWorkerControls[type].Add(control);
            AddWorkerGauge(type: type, gauge: control.Gauge);
        }

        public void AddWorkerGauge(ResourceType type, WorkerGauge gauge) { _resourcesWorkerGauges[type].Add(gauge); }

        [Serializable]
        public class ResourceToResourceGaugeMap
        {
            public ResourceType ResourceType;
            public ResourceGauge ResourceGauge;
        }

        [Serializable]
        public class ResourceToResourceControlMap
        {
            public ResourceType ResourceType;
            public ResourceControl ResourceControl;
        }

        [Serializable]
        public class ResourceToWorkerGaugeMap
        {
            public ResourceType ResourceType;
            public WorkerGauge WorkerGauge;
        }

        [Serializable]
        public class ResourceToWorkerControlMap
        {
            public ResourceType ResourceType;
            public WorkerControl WorkerControl;
        }
    }
}
