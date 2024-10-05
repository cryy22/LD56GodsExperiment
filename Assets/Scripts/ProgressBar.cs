using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image FillImage;

        public void SetColor(Color color) { FillImage.color = color; }
        public void SetProgress(float value) { FillImage.fillAmount = value; }
    }
}
