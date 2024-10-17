using UnityEngine;

namespace GodsExperiment
{
    public class StatsTable : MonoBehaviour
    {
        private static GameState State => GameState.I;

        [SerializeField] private StatsTableRow RowPrefab;
        [SerializeField] private Sprite WorkerSprite;

        private void Start()
        {
            StatsTableRow row = Instantiate(original: RowPrefab, parent: transform);
            row.StatImage.sprite = WorkerSprite;
            row.StatNameText.text = "total";
            row.StatValueText.text = State.Workers.GetTotalWorkers().ToString();

            foreach (ResourceType resourceType in State.Resources.ResourceTypes)
            {
                ResourceState resource = State.Resources[resourceType];
                Sprite resourceSprite = State.Config.GetSpriteForResource(resourceType);

                row = Instantiate(original: RowPrefab, parent: transform);
                row.StatImage.sprite = resourceSprite;
                row.StatNameText.text = "created";
                row.StatValueText.text = $"{resource.TotalCreated:F1}";

                row = Instantiate(original: RowPrefab, parent: transform);
                row.StatImage.sprite = resourceSprite;
                row.StatNameText.text = "mouse-days";
                row.StatValueText.text = $"{resource.TotalWorkUnits / State.Time.TimePerDay:F1}";
            }
        }
    }
}
