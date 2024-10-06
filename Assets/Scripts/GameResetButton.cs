using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class GameResetButton : MonoBehaviour
    {
        [SerializeField] private Button Button;

        private void OnEnable() { Button.onClick.AddListener(OnResetButtonPressed); }

        private void OnDisable() { Button.onClick.RemoveAllListeners(); }

        private void OnResetButtonPressed() { GameState.I.Input.ResetRequested = true; }
    }
}
