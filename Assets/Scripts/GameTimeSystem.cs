using UnityEngine;

namespace GodsExperiment
{
    public class GameTimeSystem
    {
        public void Update(TimeState state, InputState inputState)
        {
            state.DayChanged = false;

            if (inputState.PausePressed)
                state.IsTimePaused = !state.IsTimePaused;

            state.DeltaTime = !state.IsTimePaused
                ? Time.deltaTime * state.TimeSpeed
                : 0;
            state.Time += state.DeltaTime;

            if (state.Time >= state.TimePerDay)
            {
                state.Day += 1;
                state.Time -= state.TimePerDay;
                state.DayChanged = true;
            }
        }
    }
}
