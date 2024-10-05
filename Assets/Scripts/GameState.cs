using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Custom/Game State")]
    public class GameState : ScriptableObject
    {
        private static GameState _instance;
        public static GameState I => _instance ??= Resources.Load<GameState>("State/GameState");

        public TimeState TimeState { get; private set; } = new TimeState();
        public ResourceState ResourceState { get; private set; } = new ResourceState();
        public InputState InputState { get; private set; } = new InputState();

        public void ResetAll()
        {
            TimeState = new TimeState();
            ResourceState = new ResourceState();
            InputState = new InputState();
        }
    }
}
