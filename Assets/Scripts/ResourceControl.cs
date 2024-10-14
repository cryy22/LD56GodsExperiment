using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class ResourceControl : MonoBehaviour
    {
        [field: SerializeField] public ResourceGauge ResourceGauge { get; private set; }
        [field: SerializeField] public WorkerControl WorkerControl { get; private set; }
        [field: SerializeField] public TMP_Text WorkerCountText { get; private set; }
        [field: SerializeField] public TMP_Text RateOfProductionText { get; private set; }
        [field: SerializeField] public GameObject ResourceRequirementsSign;

        [SerializeField] private ResourceCountLabel ResourceCountLabelPrefab;

        public readonly Dictionary<ResourceType, ResourceCountLabel> ResourcesCountLabels = new();

        private void Awake() { ResourceRequirementsSign.SetActive(false); }

        public void SetResourceCosts(Dictionary<ResourceType, float> resourceCosts)
        {
            foreach (Transform child in ResourceRequirementsSign.transform)
                Destroy(child.gameObject);

            foreach ((ResourceType resourceType, float cost) in resourceCosts)
            {
                ResourceCountLabel countLabel = Instantiate(
                    original: ResourceCountLabelPrefab,
                    parent: ResourceRequirementsSign.transform
                );

                countLabel.SetIcon(GameState.I.Config.GetSpriteForResource(resourceType));
                countLabel.SetCount(cost);

                ResourcesCountLabels[resourceType] = countLabel;
            }
        }
    }
}
