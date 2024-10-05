using System;
using UnityEngine;

namespace GodsExperiment
{
    public class UIState : MonoBehaviour
    {
        [field: SerializeField] public ResourceToResourceGaugeMap[] ResourceGauges { get; private set; }
        [field: SerializeField] public ResourceToWorkerControlMap[] WorkerControls { get; private set; }
        [field: SerializeField] public ResourceToWorkerGaugeMap[] WorkerGauges { get; private set; }
        [field: SerializeField] public WorkerGauge UnemploymentGauge { get; private set; }

        [Serializable]
        public class ResourceToResourceGaugeMap
        {
            public ResourceType ResourceType;
            public ResourceGauge ResourceGauge;
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
