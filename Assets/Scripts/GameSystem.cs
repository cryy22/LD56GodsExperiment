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
        private WorkerAssignmentSystem _workerAssignmentSystem;
        private FoodSystem _foodSystem;

        private void Start()
        {
            State.ResetAll();
            UIState.ResetAll();

            _gameTimeSystem = new GameTimeSystem();
            _resourceProgressSystem = new ResourceProgressSystem();
            _inputSystem = new InputSystem();
            _uiSystem = new UISystem(config: State.Config, uiState: UIState);
            _workerAssignmentSystem = new WorkerAssignmentSystem();
            _foodSystem = new FoodSystem();
        }

        private void Update()
        {
            _inputSystem.Update(input: State.Input, uiState: UIState);
            _gameTimeSystem.Update(time: State.Time, input: State.Input);
            _workerAssignmentSystem.Update(workers: State.Workers, resources: State.Resources, input: State.Input);
            _resourceProgressSystem.Update(resources: State.Resources, workers: State.Workers, time: State.Time);
            _foodSystem.Update(time: State.Time, food: State.Resources[ResourceType.Food], workers: State.Workers);
            _uiSystem.Update(state: State, uiState: UIState);
        }
    }
}
