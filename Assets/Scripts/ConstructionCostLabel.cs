using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ConstructionCostLabel : MonoBehaviour
    {
        [SerializeField] private GameObject CostLabel;
        [SerializeField] private Image ResourceIcon;
        [SerializeField] private TMP_Text ResourceQuantityText;

        public void SetCost(Dictionary<ResourceType, float> resourceCost)
        {
            bool hasRequiredResource = resourceCost.Count > 0;
            CostLabel.SetActive(hasRequiredResource);
            ResourceIcon.gameObject.SetActive(hasRequiredResource);
            ResourceQuantityText.gameObject.SetActive(hasRequiredResource);

            if (hasRequiredResource)
                foreach ((ResourceType resourceType, float cost) in resourceCost)
                {
                    ResourceIcon.sprite = ResourceDefinitionIndex.I.GetSpriteForResource(resourceType);
                    ResourceQuantityText.text = cost.ToString(CultureInfo.InvariantCulture);
                    return; // hack to just use the fist resource
                }
        }
    }
}
