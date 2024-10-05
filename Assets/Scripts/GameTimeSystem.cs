using UnityEngine;

namespace GodsExperiment
{
    public class GameTimeSystem
    {
        public void Update(TimeState state)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                state.IsTimePaused = !state.IsTimePaused;

            state.DeltaTime = !state.IsTimePaused 
                ? Time.deltaTime * state.TimeSpeed
                : 0;
            state.Time += state.DeltaTime;
        
            Debug.Log(state.Time);
        }
    }
}
