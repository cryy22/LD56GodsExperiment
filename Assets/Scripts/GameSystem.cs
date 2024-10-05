using UnityEngine;

namespace GodsExperiment
{
    public class GameSystem : MonoBehaviour
    {
        private GameTimeSystem _gameTimeSystem;
        private ResourceProgressSystem _resourceProgressSystem;
        private InputSystem _inputSystem;
        
        private static GameState State => GameState.I;

        private void Start()
        {
            State.ResetAll();
            
            _gameTimeSystem = new GameTimeSystem();
            _resourceProgressSystem = new ResourceProgressSystem();
            _inputSystem = new InputSystem();
        }

        private void Update()
        {
            _inputSystem.Update(State.InputState);
            _gameTimeSystem.Update(State.TimeState, State.InputState);
            _resourceProgressSystem.Update(State.ResourceState, State.TimeState);
        }
    }
}
