using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace GodsExperiment
{
    public class ReturnToTitleButton : MonoBehaviour
    {
        [SerializeField] private Button Button;

        private void OnEnable() { Button.onClick.AddListener(OnButtonPressed); }

        private void OnDisable() { Button.onClick.RemoveAllListeners(); }

        private void OnButtonPressed() { GameState.I.Input.TitleRequested = true; }
    }
}
