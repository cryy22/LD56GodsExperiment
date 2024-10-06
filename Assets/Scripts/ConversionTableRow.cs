using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ConversionTableRow : MonoBehaviour
    {
        [SerializeField] private Image TargetResourceIcon;
        [SerializeField] private Image SourceResourceIcon;
        [SerializeField] private TMP_Text SourceResourceCountText;

        public void SetResourceCosts(
            ResourceType resourceType,
            Dictionary<ResourceType, float> resourceCosts,
            GameConfig config
        )
        {
            TargetResourceIcon.sprite = config.GetSpriteForResource(resourceType);
            foreach ((ResourceType sourceResourceType, float cost) in resourceCosts)
            {
                SourceResourceIcon.sprite = config.GetSpriteForResource(sourceResourceType);
                SourceResourceCountText.text = $"{(int) cost}";
            }
        }
    }
}
