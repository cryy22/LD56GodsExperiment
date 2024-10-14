using UnityEngine;

namespace GodsExperiment
{
    public class WorkforceTooltipPopulator : MonoBehaviour, TooltipPopulator.IPopulator
    {
        [SerializeField] [TextArea] private string FullEmploymentText;
        [SerializeField] [TextArea] private string SomeUnemploymentText;
        [SerializeField] [TextArea] private string TotalUnemploymentText;

        public string GetTooltipText(GameState state)
        {
            if (state.Workers[ResourceType.None] == state.Workers.GetTotalWorkers())
                return TotalUnemploymentText;
            if (state.Workers[ResourceType.None] == 0)
                return FullEmploymentText;

            return SomeUnemploymentText;
        }
    }
}
