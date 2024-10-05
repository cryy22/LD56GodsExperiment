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
        private FoodSystem _foodSystem;

        private void Start()
        {
            State.ResetAll();
            UIState.ResetAll();

            _gameTimeSystem = new GameTimeSystem();
            _resourceProgressSystem = new ResourceProgressSystem();
            _inputSystem = new InputSystem();
            _uiSystem = new UISystem(config: State.Config, uiState: UIState);
            _workerSystem = new WorkerSystem();
            _foodSystem = new FoodSystem();
        }

        private void Update()
        {
            _inputSystem.Update(state: State.Input, uiState: UIState);
            _gameTimeSystem.Update(state: State.Time, inputState: State.Input);
            _workerSystem.Update(workers: State.Workers, input: State.Input);
            _resourceProgressSystem.Update(state: State.Resources, workersState: State.Workers, timeState: State.Time);
            _foodSystem.Update(time: State.Time, food: State.Resources[ResourceType.Food], workers: State.Workers);
            _uiSystem.Update(gameState: State, uiState: UIState);
        }
    }
}
