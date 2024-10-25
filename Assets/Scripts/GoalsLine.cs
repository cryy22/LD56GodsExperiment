using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class GoalsLine : MonoBehaviour
    {
        [SerializeField] private TMP_Text CurrentDayCount;
        [SerializeField] private TMP_Text TotalDayCount;
        [SerializeField] private ResourceGoalMeter GoalMeterPrefab;

        [SerializeField] private GameObject DividerPrefab;
    }
}
