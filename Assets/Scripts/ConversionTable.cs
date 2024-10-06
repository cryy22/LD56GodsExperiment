using UnityEngine;

namespace GodsExperiment
{
    public class ConversionTable : MonoBehaviour
    {
        [SerializeField] private Transform RowParent;
        [SerializeField] private ConversionTableRow RowPrefab;

        public void SetResourceCosts(ResourcesState resources, GameConfig config)
        {
            foreach (Transform child in RowParent)
                Destroy(child.gameObject);

            foreach (ResourceType resourceType in resources.ResourceTypes)
            {
                if (resources[resourceType].ResourceCosts.Count == 0) continue;

                ConversionTableRow row = Instantiate(original: RowPrefab, parent: RowParent);
                row.SetResourceCosts(
                    resourceType: resourceType,
                    resourceCosts: resources[resourceType].ResourceCosts,
                    config: config
                );
            }
        }
    }
}
