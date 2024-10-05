using UnityEngine;

namespace GodsExperiment
{
    public class GameSystem : MonoBehaviour
    {
        private static GameState State => GameState.I;
        [SerializeField] private UIState UIState;

        private GameTimeSystem _gameTimeSystem;
        private ResourceProgressSystem _resourceProgressSystem;
        private InputSystem _inputSystem;
        private UISystem _uiSystem;

        private void Start()
        {
            State.ResetAll();

            _gameTimeSystem = new GameTimeSystem();
            _resourceProgressSystem = new ResourceProgressSystem();
            _inputSystem = new InputSystem();
            _uiSystem = new UISystem();
        }

        private void Update()
        {
            _inputSystem.Update(State.Input);
            _gameTimeSystem.Update(state: State.Time, inputState: State.Input);
            _resourceProgressSystem.Update(state: State.Resources, timeState: State.Time);
            _uiSystem.Update(gameState: State, uiState: UIState);
        }
    }
}
