using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class HypothesisStatementIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text InitialWorkersCountText;
        [SerializeField] private Transform TargetResourcesContainer;
        [SerializeField] private ResourceCountLabel ResourceCountLabelPrefab;
        [SerializeField] private TMP_Text TargetDaysText;

        public void Initialize(GameState state)
        {
            foreach (Transform child in TargetResourcesContainer)
                Destroy(child.gameObject);

            InitialWorkersCountText.text = state.Config.InitialWorkers.ToString();
            foreach (ResourceTarget target in state.Config.ResourceTargets)
            {
                ResourceCountLabel countLabel = Instantiate(
                    original: ResourceCountLabelPrefab,
                    parent: TargetResourcesContainer
                );
                countLabel.SetCount(target.TargetAmount);
                countLabel.SetIcon(ResourceDefinitionIndex.I.GetSpriteForResource(target.ResourceType));
            }

            TargetDaysText.text = $"in {state.Config.TotalDays.ToString()} days";
        }
    }
}
