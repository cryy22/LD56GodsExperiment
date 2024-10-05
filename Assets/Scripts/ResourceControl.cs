using UnityEngine;

namespace GodsExperiment
{
    public class ResourceControl : MonoBehaviour
    {
        [field: SerializeField] public ResourceGauge ResourceGauge { get; private set; }
        [field: SerializeField] public WorkerControl WorkerControl { get; private set; }
    }
}
