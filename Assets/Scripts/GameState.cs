using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Custom/Game State")]
public class GameState : ScriptableObject
{
    private static GameState _instance;
    public static GameState I => _instance ??= Resources.Load<GameState>("State/GameState");

    [field: NonSerialized] public float Time { get; set; } = 0;
    [field: NonSerialized] public float TimeSpeed { get; set; } = 1;
    [field: NonSerialized] public bool IsTimePaused { get; set; } = true;

    public void ResetAll()
    {
        Time = 0;
        TimeSpeed = 1;
        IsTimePaused = true;
    }
}
