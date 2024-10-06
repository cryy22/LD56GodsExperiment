using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ResourceGauge : MonoBehaviour
    {
        [SerializeField] private TMP_Text CountText;
        [SerializeField] private Image IconImage;
        [SerializeField] private ProgressBar ProgressBar;

        public void SetIcon(Sprite icon) { IconImage.sprite = icon; }
        public void SetColor(Color color) { ProgressBar.SetColor(color); }

        public void SetValues(float count, float progress)
        {
            CountText.text = ((int) count).ToString();
            ProgressBar.SetProgress(progress);
        }
    }
}
