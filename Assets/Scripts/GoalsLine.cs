using UnityEngine;

namespace GodsExperiment
{
    public class GoalsLine : MonoBehaviour
    {
        [SerializeField] private DaysGauge DaysGaugePrefab;
        [SerializeField] private ResourceGoalGauge GoalGaugePrefab;
        [SerializeField] private GameObject DividerPrefab;

        public void Initialize(GameState state, ResourceTarget[] targets, int totalDays)
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);

            DaysGauge daysGauge = Instantiate(original: DaysGaugePrefab, parent: transform);
            daysGauge.Initialize(time: state.Time, totalDayCount: totalDays);

            foreach (ResourceTarget target in targets)
            {
                Instantiate(original: DividerPrefab, parent: transform);
                ResourceGoalGauge goalGauge = Instantiate(original: GoalGaugePrefab, parent: transform);
                goalGauge.Initialize(resource: state.Resources[target.ResourceType], amount: target.TargetAmount);
            }
        }
    }
}
