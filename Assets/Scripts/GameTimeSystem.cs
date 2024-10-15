using UnityEngine;

namespace GodsExperiment
{
    public class GameTimeSystem
    {
        public void Update(TimeState time, InputState input)
        {
            time.DayChanged = false;

            if (time.IsTimePaused && input.AnyPlayButtonPressed)
                time.IsTimePaused = false;
            else if (input.PausePressed)
                time.IsTimePaused = !time.IsTimePaused;

            if (input.PlayPressed)
                time.TimeSpeed = Constants.PlaySpeed;
            if (input.FastForwardPressed)
                time.TimeSpeed = Constants.FastForwardSpeed;
            if (input.VeryFastForwardPressed)
                time.TimeSpeed = Constants.VeryFastForwardSpeed;

            input.PausePressed = false;
            input.PlayPressed = false;
            input.FastForwardPressed = false;
            input.VeryFastForwardPressed = false;

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
