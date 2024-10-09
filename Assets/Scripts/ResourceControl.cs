using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class ResourceControl : MonoBehaviour
    {
        [field: SerializeField] public ResourceGauge ResourceGauge { get; private set; }
        [field: SerializeField] public WorkerControl WorkerControl { get; private set; }
        [field: SerializeField] public TMP_Text WorkerCountText { get; private set; }
        [field: SerializeField] public TMP_Text RateOfProductionText { get; private set; }
    }
}
