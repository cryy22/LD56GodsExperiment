using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class UIState : MonoBehaviour
    {
        [field: SerializeField] public ResourceGauge BooiteGauge { get; private set; }
        [field: SerializeField] public ResourceGauge BooiumGauge { get; private set; }
    }
}
