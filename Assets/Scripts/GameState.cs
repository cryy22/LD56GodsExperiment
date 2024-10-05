using UnityEngine;
using UnityEngine.Serialization;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Custom/Game State")]
    public class GameState : ScriptableObject
    {
        private static GameState _instance;
        public static GameState I => _instance ??= Resources.Load<GameState>("State/GameState");

        [SerializeField] private ResourceRequirements BooiteResourceRequirements;
        [SerializeField] private ResourceRequirements BooiumResourceRequirements;

        public TimeState TimeState { get; private set; }
        public ResourcesState ResourcesState { get; private set; }
        public InputState InputState { get; private set; }

        public void ResetAll()
        {
            TimeState = new TimeState();
            ResourcesState = new ResourcesState(BooiteResourceRequirements, BooiumResourceRequirements);
            InputState = new InputState();
        }
    }
}
