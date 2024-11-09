using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ClearConstructionQueueButton : MonoBehaviour
    {
        [SerializeField] private Button Button;

        private void OnEnable() { Button.onClick.AddListener(OnButtonPressed); }
        private void OnDisable() { Button.onClick.RemoveAllListeners(); }
        private void OnButtonPressed() { GameState.I.Input.ConstructionQueueClearRequested = true; }
    }
}
