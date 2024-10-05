using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeAdvancer : MonoBehaviour
{
    public static GameState State => GameState.I;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            State.IsTimePaused = !State.IsTimePaused;
        
        if (!State.IsTimePaused)
            State.Time += Time.deltaTime * State.TimeSpeed;
        
        Debug.Log(State.Time);
    }
}
