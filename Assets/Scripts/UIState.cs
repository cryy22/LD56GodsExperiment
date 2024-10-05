using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class UIState : MonoBehaviour
    {
        [field: SerializeField] public ProgressBar BooiteProgressBar { get; private set; }
        [field: SerializeField] public TMP_Text BooiteCount { get; private set; }
    }
}
