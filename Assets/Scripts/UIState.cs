using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class UIState : MonoBehaviour
    {
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

        [field: SerializeField] public ProgressBar DayProgressBar { get; private set; }
        [field: SerializeField] public TMP_Text CurrentDayCount { get; private set; }
        [field: SerializeField] public TMP_Text TotalDaysCount { get; private set; }
        [field: SerializeField] public TMP_Text CurrentBoosCount { get; private set; }
        [field: SerializeField] public TMP_Text TotalBoosCount { get; private set; }

        [field: SerializeField] public Tooltip Tooltip { get; private set; }

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
                _resourcesResourceControls[map.ResourceType].Add(map.ResourceControl);
            foreach (ResourceToResourceGaugeMap map in ResourceGauges)
                _resourcesResourceGauges[map.ResourceType].Add(map.ResourceGauge);
            foreach (ResourceToWorkerControlMap map in WorkerControls)
                _resourcesWorkerControls[map.ResourceType].Add(map.WorkerControl);
            foreach (ResourceToWorkerGaugeMap map in WorkerGauges)
                _resourcesWorkerGauges[map.ResourceType].Add(map.WorkerGauge);

            foreach ((ResourceType resourceType, List<ResourceControl> resourceControls) in _resourcesResourceControls)
            foreach (ResourceControl control in resourceControls)
            {
                _resourcesResourceGauges[resourceType].Add(control.ResourceGauge);
                _resourcesWorkerControls[resourceType].Add(control.WorkerControl);
            }

            foreach ((ResourceType resourceType, List<WorkerControl> workerControls) in _resourcesWorkerControls)
            foreach (WorkerControl control in workerControls)
                _resourcesWorkerGauges[resourceType].Add(control.Gauge);
        }

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
