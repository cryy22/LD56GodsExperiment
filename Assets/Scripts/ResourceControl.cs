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
        private readonly Dictionary<ResourceType, ResourceCountLabel> _resourcesCountLabels = new();

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

                countLabel.SetIcon(ResourceDefinitionIndex.I.GetSpriteForResource(resourceType));
                countLabel.SetCount(cost);

                _resourcesCountLabels[resourceType] = countLabel;
            }
        }
    }
}
