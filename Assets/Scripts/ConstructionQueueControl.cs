using UnityEngine;

namespace GodsExperiment
{
    public class ConstructionQueueControl : MonoBehaviour
    {
        [SerializeField] private Transform ItemParent;
        [SerializeField] private ConstructionQueueControlItem ItemPrefab;

        public void SetAvailableResources(ResourceType[] resourceTypes, GameConfig config)
        {
            foreach (Transform child in ItemParent)
                Destroy(child.gameObject);

            foreach (ResourceType resourceType in resourceTypes)
            {
                ConstructionQueueControlItem item = Instantiate(original: ItemPrefab, parent: ItemParent);
                item.ResourceType = resourceType;
                item.SetIcon(config.GetSpriteForResource(resourceType));
            }
        }
    }
}
