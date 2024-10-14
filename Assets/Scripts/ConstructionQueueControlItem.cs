using System;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ConstructionQueueControlItem : MonoBehaviour
    {
        private static InputState Input => GameState.I.Input;
        [SerializeField] private HoverButton HoverButton;
        [SerializeField] private Image ResourceIconImage;

        public ResourceType ResourceType { get; set; }

        private void OnEnable()
        {
            HoverButton.onClick.AddListener(OnClicked);
            HoverButton.Hovered += OnHovered;
            HoverButton.Unhovered += OnUnhovered;
        }

        private void OnDisable()
        {
            HoverButton.onClick.RemoveAllListeners();
            HoverButton.Hovered -= OnHovered;
            HoverButton.Unhovered -= OnUnhovered;
        }

        public void SetIcon(Sprite icon) { ResourceIconImage.sprite = icon; }
        public void SetInteractable(bool interactable) { HoverButton.interactable = interactable; }

        private void OnClicked()
        {
            Input.ConstructionRequested = ResourceType;
            Input.ConstructionChangeMassModifier =
                UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
        }

        private void OnHovered(object sender, EventArgs e) { }
        private void OnUnhovered(object sender, EventArgs e) { }
    }
}
