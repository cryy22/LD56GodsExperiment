using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class ResourceGauge : MonoBehaviour
    {
        [SerializeField] private TMP_Text CountText;
        [SerializeField] private TMP_Text NameText;
        [SerializeField] private ProgressBar ProgressBar;

        public void SetName(string resourceName) { NameText.text = resourceName; }
        public void SetColor(Color color) { ProgressBar.SetColor(color); }

        public void SetValues(float count, float progress)
        {
            CountText.text = ((int) count).ToString();
            ProgressBar.SetProgress(progress);
        }
    }
}
