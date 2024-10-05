using UnityEngine;

namespace GodsExperiment
{
    public class GameTimeSystem
    {
        public void Update(TimeState time, InputState input)
        {
            time.DayChanged = false;

            if (input.PausePressed)
                time.IsTimePaused = !time.IsTimePaused;

            time.DeltaTime = !time.IsTimePaused
                ? Time.deltaTime * time.TimeSpeed
                : 0;
            time.Time += time.DeltaTime;

            if (time.Time >= time.TimePerDay)
            {
                time.Day += 1;
                time.Time -= time.TimePerDay;
                time.DayChanged = true;
            }
        }
    }
}
