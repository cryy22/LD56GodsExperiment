using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Custom/Game State")]
    public class GameState : ScriptableObject
    {
        private static GameState _instance;
        public static GameState I => _instance ??= Resources.Load<GameState>("State/GameState");

        [SerializeField] private float WorkUnitsPerBooite;

        public TimeState TimeState { get; private set; }
        public ResourceState ResourceState { get; private set; }
        public InputState InputState { get; private set; }

        public void ResetAll()
        {
            TimeState = new TimeState();
            
            ResourceState = new ResourceState
            {
                WorkUnitsPerBooite = WorkUnitsPerBooite,
            };

            InputState = new InputState();
        }
    }
}
