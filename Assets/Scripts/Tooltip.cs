using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private TMP_Text TooltipText;

        public void SetContent(string content)
        {
            gameObject.SetActive(content.Length > 0);
            TooltipText.text = content;
        }
    }
}
