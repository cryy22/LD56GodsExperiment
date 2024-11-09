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

        public void SetCost(ResourceQuantity[] resourceQuantities)
        {
            bool hasRequiredResource = resourceQuantities.Length > 0;
            CostLabel.SetActive(hasRequiredResource);
            ResourceIcon.gameObject.SetActive(hasRequiredResource);
            ResourceQuantityText.gameObject.SetActive(hasRequiredResource);

            if (hasRequiredResource)
            {
                ResourceIcon.sprite = ResourceDefinitionIndex.I.GetSpriteForResource(resourceQuantities[0].Resource);
                ResourceQuantityText.text = resourceQuantities[0].Quantity.ToString();
            }
        }
    }
}
