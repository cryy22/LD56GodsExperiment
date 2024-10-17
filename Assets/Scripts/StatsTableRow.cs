using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class StatsTableRow : MonoBehaviour
    {
        [field: SerializeField] public Image StatImage { get; private set; }
        [field: SerializeField] public TMP_Text StatNameText { get; private set; }
        [field: SerializeField] public TMP_Text StatValueText { get; private set; }
    }
}
