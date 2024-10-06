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

        public void SetIcon(Sprite icon)
        {
            IconImage.sprite = icon;
            IconImage.color = icon ? Color.white : Color.clear;
        }

        public void SetColor(Color color) { ProgressBar.SetColor(color); }
        public void ShowCountText(bool show) { CountText.gameObject.SetActive(show); }

        public void SetValues(float count, float progress)
        {
            CountText.text = ((int) count).ToString();
            ProgressBar.SetProgress(progress);
        }
    }
}
