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
        [SerializeField] private TMP_Text UnitsPerDayText;

        public void SetResourceCosts(
            ResourceType resourceType,
            ResourcesState resources,
            GameConfig config
        )
        {
            TargetResourceIcon.sprite = config.GetSpriteForResource(resourceType);

            if (resources[resourceType].ResourceCosts.Count > 0)
            {
                foreach ((ResourceType sourceResourceType, float cost) in resources[resourceType].ResourceCosts)
                {
                    SourceResourceIcon.sprite = config.GetSpriteForResource(sourceResourceType);
                    SourceResourceCountText.text = $"{(int) cost}";
                }
            }
            else
            {
                SourceResourceIcon.gameObject.SetActive(false);
                SourceResourceCountText.gameObject.SetActive(false);
            }

            float unitsPerDay = config.TimePerDay / resources[resourceType].WorkUnitsPerUnit;
            UnitsPerDayText.text = $"{unitsPerDay:F1}";
        }
    }
}
