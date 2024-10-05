using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Custom/Game State")]
    public class GameState : ScriptableObject
    {
        private static GameState _instance;
        public static GameState I => _instance ??= UnityEngine.Resources.Load<GameState>("State/GameState");

        [SerializeField] private int InitialWorkers;
        [SerializeField] private ResourceRequirements[] ResourceRequirements;

        public TimeState Time { get; private set; }
        public ResourcesState Resources { get; private set; }
        public InputState Input { get; private set; }

        public void ResetAll()
        {
            Time = new TimeState();
            Resources = new ResourcesState(initialWorkers: InitialWorkers, requirements: ResourceRequirements);
            Input = new InputState();
        }
    }
}
