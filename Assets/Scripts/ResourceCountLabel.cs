using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ResourceCountLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text CountText;
        [SerializeField] private Image IconImage;

        public void SetColor(Color color) { CountText.color = color; }
        public void SetCount(float count) { CountText.text = $"{count:N0}"; }
        public void SetIcon(Sprite icon) { IconImage.sprite = icon; }
    }
}
