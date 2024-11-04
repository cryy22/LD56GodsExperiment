using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class OpeningCardDismisser : MonoBehaviour
    {
        [SerializeField] private Button DismissButton;

        private void OnEnable() { DismissButton.onClick.AddListener(OnDismissPressed); }
        private void OnDisable() { DismissButton.onClick.RemoveListener(OnDismissPressed); }
        private void OnDismissPressed() { GameState.I.Input.OpeningCardDismissRequested = true; }
    }
}
