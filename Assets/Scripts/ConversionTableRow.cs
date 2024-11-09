using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ConversionTableRow : MonoBehaviour
    {
        [SerializeField] private Image TargetResourceIcon;
        [SerializeField] private Image SourceResourceIcon1;
        [SerializeField] private TMP_Text SourceResourceCountText1;
        [SerializeField] private Image SourceResourceIcon2;
        [SerializeField] private TMP_Text SourceResourceCountText2;
        [SerializeField] private TMP_Text UnitsPerDayText;

        public void SetResourceCosts(
            ResourceType resourceType,
            ResourcesState resources,
            GameConfig config
        )
        {
            TargetResourceIcon.sprite = ResourceDefinitionIndex.I.GetSpriteForResource(resourceType);

            SourceResourceIcon1.gameObject.SetActive(false);
            SourceResourceCountText1.gameObject.SetActive(false);
            SourceResourceIcon2.gameObject.SetActive(false);
            SourceResourceCountText2.gameObject.SetActive(false);

            var sourceResourceIndex = 1;
            foreach ((ResourceType sourceResourceType, float cost) in resources[resourceType].ResourceCosts)
            {
                if (sourceResourceIndex > 2)
                    break;

                Image icon = sourceResourceIndex switch
                {
                    1 => SourceResourceIcon1,
                    _ => SourceResourceIcon2,
                };

                TMP_Text text = sourceResourceIndex switch
                {
                    1 => SourceResourceCountText1,
                    _ => SourceResourceCountText2,
                };

                icon.gameObject.SetActive(true);
                icon.sprite = ResourceDefinitionIndex.I.GetSpriteForResource(sourceResourceType);

                text.gameObject.SetActive(true);
                text.text = $"{(int) cost}";

                sourceResourceIndex++;
            }

            float unitsPerDay = config.TimePerDay / resources[resourceType].WorkUnitsPerUnit;
            UnitsPerDayText.text = $"{unitsPerDay:F1}";
        }
    }
}
