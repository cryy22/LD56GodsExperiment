using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class Tooltip : MonoBehaviour
    {
        private static InputState Input => GameState.I.Input;

        [SerializeField] private GameObject TooltipBubble;
        [SerializeField] private TMP_Text TooltipText;
        [SerializeField] private Button TooltipToggle;

        private void Update()
        {
            TooltipToggle.targetGraphic.color = Input.IsTooltipEnabled ? Color.white : Constants.LightGray;
        }

        private void OnEnable() { TooltipToggle.onClick.AddListener(OnTooltipToggled); }
        private void OnDisable() { TooltipToggle.onClick.RemoveListener(OnTooltipToggled); }

        public void SetContent(string content)
        {
            TooltipBubble.SetActive(content.Length > 0);
            TooltipText.text = content;
        }

        private void OnTooltipToggled() { Input.IsTooltipEnabled = !Input.IsTooltipEnabled; }
    }
}
