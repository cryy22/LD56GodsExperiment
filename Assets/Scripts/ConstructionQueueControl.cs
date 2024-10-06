using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class ConstructionQueueControl : MonoBehaviour
    {
        [SerializeField] private Transform ItemParent;
        [SerializeField] private ConstructionQueueControlItem ItemPrefab;

        private readonly List<ConstructionQueueControlItem> _items = new();

        public void SetAvailableResources(ResourceType[] resourceTypes, GameConfig config)
        {
            foreach (ConstructionQueueControlItem item in _items)
                Destroy(item.gameObject);

            _items.Clear();

            foreach (Transform child in ItemParent)
                Destroy(child.gameObject);

            foreach (ResourceType resourceType in resourceTypes)
            {
                ConstructionQueueControlItem item = Instantiate(original: ItemPrefab, parent: ItemParent);
                item.ResourceType = resourceType;
                item.SetIcon(config.GetSpriteForResource(resourceType));

                _items.Add(item);
            }
        }

        public void SetControlsInteractabilities(ResourcesState resources, GameConfig config)
        {
            foreach (ConstructionQueueControlItem item in _items)
                item.SetInteractable(resources[item.ResourceType].WorkerSlots < config.MaxWorkersPerResource);
        }
    }
}
