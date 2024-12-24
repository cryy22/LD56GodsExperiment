using UnityEngine;

namespace GodsExperiment
{
    public class StatsTable : MonoBehaviour
    {
        private static GameState State => GameState.I;

        [SerializeField] private Transform RowParent;
        [SerializeField] private StatsTableRow RowPrefab;
        [SerializeField] private Sprite WorkerSprite;

        private void Start()
        {
            StatsTableRow timeRow = Instantiate(original: RowPrefab, parent: RowParent);
            timeRow.StatImage.gameObject.SetActive(false);
            timeRow.StatNameText.text = "days";
            timeRow.StatValueText.text =
                $"{string.Format(format: "{0:0.00}", arg0: State.Time.Day + State.Time.Time / State.Time.TimePerDay)}";

            StatsTableRow workersRow = Instantiate(original: RowPrefab, parent: RowParent);
            workersRow.StatImage.sprite = WorkerSprite;
            workersRow.StatNameText.text = "total";
            workersRow.StatValueText.text = State.Workers.GetTotalWorkers().ToString();

            foreach (ResourceType resourceType in State.Resources.ResourceTypes)
            {
                ResourceState resource = State.Resources[resourceType];
                Sprite resourceSprite = ResourceDefinitionIndex.I.GetSpriteForResource(resourceType);

                workersRow = Instantiate(original: RowPrefab, parent: RowParent);
                workersRow.StatImage.sprite = resourceSprite;
                workersRow.StatNameText.text = "created";
                workersRow.StatValueText.text = $"{resource.TotalCreated:F1}";

                workersRow = Instantiate(original: RowPrefab, parent: RowParent);
                workersRow.StatImage.sprite = resourceSprite;
                workersRow.StatNameText.text = "mouse-days";
                workersRow.StatValueText.text = $"{resource.TotalWorkUnits / State.Time.TimePerDay:F1}";
            }
        }
    }
}
