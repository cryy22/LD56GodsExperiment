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
        [SerializeField] private TooltipSpeakerAnimator Animator;

        private string _currentContent;

        private void Update()
        {
            TooltipToggle.targetGraphic.color = Input.IsTooltipEnabled ? Color.white : Constants.LightGray;
        }

        private void OnEnable() { TooltipToggle.onClick.AddListener(OnTooltipToggled); }
        private void OnDisable() { TooltipToggle.onClick.RemoveListener(OnTooltipToggled); }

        public void SetContent(string content)
        {
            if (content == _currentContent)
                return;
            _currentContent = content;

            TooltipText.text = content;
            if (content.Length > 0)
            {
                TooltipBubble.SetActive(true);
                Animator.Run();
            }
            else
            {
                TooltipBubble.SetActive(false);
                Animator.Stop();
            }
        }

        private void OnTooltipToggled() { Input.IsTooltipEnabled = !Input.IsTooltipEnabled; }
    }
}
