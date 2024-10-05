using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image FillImage;

        public void SetProgress(float value)
        {
            FillImage.fillAmount = value;
        }
    }
}