using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image FillImage;

        private void Start()
        {
            FillImage.fillAmount = 0.5f;
        }
    }
}
