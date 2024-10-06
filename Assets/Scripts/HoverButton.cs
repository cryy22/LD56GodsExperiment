using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class HoverButton : Button
    {
        public event EventHandler Hovered;
        public event EventHandler Unhovered;
        public bool IsHovered { get; private set; }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            IsHovered = true;
            Hovered?.Invoke(sender: this, e: EventArgs.Empty);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            IsHovered = false;
            Unhovered?.Invoke(sender: this, e: EventArgs.Empty);
        }
    }
}
