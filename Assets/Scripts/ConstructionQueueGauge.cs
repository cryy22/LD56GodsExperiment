using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GodsExperiment
{
    public class ConstructionQueueGauge : MonoBehaviour
    {
        [SerializeField] private Transform ConstructionIconParent;
        [SerializeField] private ConstructionIcon ConstructionIconPrefab;
        [FormerlySerializedAs("QueueEmptyText")] [SerializeField] private GameObject QueueEmptyPlaceholder;

        private readonly List<ConstructionIcon> _constructionIcons = new();

        private void Awake()
        {
            foreach (Transform child in ConstructionIconParent)
                Destroy(child.gameObject);
        }

        public void SetConstructionQueue(IEnumerable<ResourceType> queuedResourceTypes, GameConfig config)
        {
            var i = 0;
            foreach (ResourceType resourceType in queuedResourceTypes)
            {
                if (_constructionIcons.Count == i)
                    _constructionIcons.Add(
                        Instantiate(original: ConstructionIconPrefab, parent: ConstructionIconParent)
                    );

                _constructionIcons[i].SetResourceIcon(config.GetSpriteForResource(resourceType));

                i++;
            }

            while (i < _constructionIcons.Count)
            {
                Destroy(_constructionIcons[i].gameObject);
                _constructionIcons.RemoveAt(i);
            }

            QueueEmptyPlaceholder.gameObject.SetActive(_constructionIcons.Count == 0);
        }
    }
}
