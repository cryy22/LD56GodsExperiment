using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ResourceGoalMeter : MonoBehaviour
    {
        [SerializeField] private Image Icon;
        [SerializeField] private TMP_Text CurrentCount;
        [SerializeField] private TMP_Text TotalCount;

        public ResourceType ResourceType { get; private set; }

        private void Update() { }
    }
}
