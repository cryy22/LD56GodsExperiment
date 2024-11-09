using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class ConstructionQueueGauge : MonoBehaviour
    {
        [SerializeField] private Transform ConstructionIconParent;
        [SerializeField] private ConstructionIcon ConstructionIconPrefab;
        [SerializeField] private GameObject ShowWithQueueContainer;
        [SerializeField] private GameObject ShowWithNoQueueContainer;

        private readonly List<ConstructionIcon> _constructionIcons = new();

        private void Awake()
        {
            foreach (Transform child in ConstructionIconParent)
                Destroy(child.gameObject);
        }

        public void SetConstructionQueue(IEnumerable<ResourceType> queuedResourceTypes)
        {
            var i = 0;
            foreach (ResourceType resourceType in queuedResourceTypes)
            {
                if (_constructionIcons.Count == i)
                    _constructionIcons.Add(
                        Instantiate(original: ConstructionIconPrefab, parent: ConstructionIconParent)
                    );

                _constructionIcons[i].SetResourceIcon(ResourceDefinitionIndex.I.GetSpriteForResource(resourceType));

                i++;
            }

            while (i < _constructionIcons.Count)
            {
                Destroy(_constructionIcons[i].gameObject);
                _constructionIcons.RemoveAt(i);
            }

            ShowWithQueueContainer.SetActive(_constructionIcons.Count > 0);
            ShowWithNoQueueContainer.SetActive(_constructionIcons.Count == 0);
        }
    }
}
