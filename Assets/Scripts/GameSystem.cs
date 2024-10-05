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
        private WorkerSystem _workerSystem;

        private void Start()
        {
            State.ResetAll();

            _gameTimeSystem = new GameTimeSystem();
            _resourceProgressSystem = new ResourceProgressSystem();
            _inputSystem = new InputSystem();
            _uiSystem = new UISystem();
            _workerSystem = new WorkerSystem();
        }

        private void Update()
        {
            _inputSystem.Update(state: State.Input, uiState: UIState);
            _gameTimeSystem.Update(state: State.Time, inputState: State.Input);
            _workerSystem.Update(resources: State.Resources, input: State.Input);
            _resourceProgressSystem.Update(state: State.Resources, timeState: State.Time);
            _uiSystem.Update(gameState: State, uiState: UIState);
        }
    }
}
