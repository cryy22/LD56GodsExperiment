using TMPro;
using UnityEngine;

namespace GodsExperiment
{
    public class DaysGauge : MonoBehaviour
    {
        [SerializeField] private TMP_Text CurrentDayCount;
        [SerializeField] private TMP_Text TotalDayCount;
        private TimeState _time;

        public void Update()
        {
            if (_time == null) return;
            CurrentDayCount.text = (_time.Day + 1).ToString();
        }

        public void Initialize(TimeState time, int totalDayCount)
        {
            _time = time;
            TotalDayCount.text = totalDayCount.ToString();
        }
    }
}
