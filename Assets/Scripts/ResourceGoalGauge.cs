using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ResourceGoalGauge : MonoBehaviour
    {
        [SerializeField] private Image Icon;
        [SerializeField] private TMP_Text CurrentCount;
        [SerializeField] private TMP_Text TotalCount;

        private ResourceState _resource;

        private void Update()
        {
            if (_resource == null) return;

            CurrentCount.text =
                ((int) _resource.Count).ToString(CultureInfo.InvariantCulture);
        }

        public void Initialize(ResourceState resource, int amount)
        {
            _resource = resource;
            Icon.sprite = ResourceDefinitionIndex.I.GetSpriteForResource(resource.Type);
            TotalCount.text = amount.ToString();
        }
    }
}
