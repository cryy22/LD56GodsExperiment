using UnityEngine;
using UnityEngine.EventSystems;

namespace GodsExperiment
{
    public class TooltipPopulator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private PopulationModeType PopulationMode;
        [SerializeField] private Object Populator;
        [SerializeField] [TextArea] private string TooltipText;

        public void OnPointerEnter(PointerEventData eventData)
        {
            GameState.I.Input.TooltipContent = PopulationMode switch
            {
                PopulationModeType.String => TooltipText,
                PopulationModeType.Proxy  => ((IPopulator) Populator).GetTooltipText(GameState.I),
                _                         => string.Empty,
            };
        }

        public void OnPointerExit(PointerEventData eventData) { GameState.I.Input.TooltipContent = string.Empty; }

        private enum PopulationModeType
        {
            String,
            Proxy,
        }

        public interface IPopulator
        {
            public string GetTooltipText(GameState state);
        }
    }
}
