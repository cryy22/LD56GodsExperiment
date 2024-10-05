using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class ResourceGauge : MonoBehaviour
    {
        [SerializeField] private TMP_Text CountText;
        [SerializeField] private TMP_Text NameText;
        [SerializeField] private ProgressBar ProgressBar;

        [SerializeField] public string TagName;

        private void Start() { NameText.text = TagName; }

        public void SetValues(float count, float progress)
        {
            CountText.text = ((int) count).ToString();
            ProgressBar.SetProgress(progress);
        }
    }
}
