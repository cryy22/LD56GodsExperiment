using UnityEngine;

namespace GodsExperiment
{
    [DefaultExecutionOrder(100)]
    public class GameSystem : MonoBehaviour
    {
        private static GameState State => GameState.I;
        [SerializeField] private UIState UIState;

        private TimeSystem _timeSystem;
        private ResourcesSystem _resourcesSystem;
        private InputSystem _inputSystem;
        private UISystem _uiSystem;
        private WorkerAssignmentSystem _workerAssignmentSystem;
        private FoodSystem _foodSystem;
        private ConstructionSystem _constructionSystem;
        private GameResultSystem _gameResultSystem;
        private NumberParticleSystem _numberParticleSystem;
        private TransientStateResetSystem _transientStateResetSystem;
        private CardMovementSystem _cardMovementSystem;

        private void Start() { Initialize(); }

        private void Update()
        {
            if (State.Input.ResetRequested)
                Initialize();

            _inputSystem.Update(input: State.Input);
            _cardMovementSystem.Update(state: State, uiState: UIState);
            _timeSystem.Update(time: State.Time, input: State.Input);
            _workerAssignmentSystem.Update(workers: State.Workers, resources: State.Resources, input: State.Input);
            _resourcesSystem.Update(resources: State.Resources, workers: State.Workers, time: State.Time);
            _constructionSystem.Update(
                construction: State.Construction,
                resources: State.Resources,
                input: State.Input,
                config: State.Config
            );
            _foodSystem.Update(time: State.Time, resources: State.Resources, workers: State.Workers);
            _gameResultSystem.Update(State);
            _numberParticleSystem.Update(resources: State.Resources, uiState: UIState);
            _uiSystem.Update(state: State, uiState: UIState);

            _transientStateResetSystem.Update(State);
        }

        private void Initialize()
        {
            State.ResetAll();
            UIState.ResetAll();

            _timeSystem = new TimeSystem();
            _resourcesSystem = new ResourcesSystem();
            _inputSystem = new InputSystem();
            _uiSystem = new UISystem(state: State, uiState: UIState);
            _workerAssignmentSystem = new WorkerAssignmentSystem();
            _foodSystem = new FoodSystem();
            _constructionSystem = new ConstructionSystem();
            _gameResultSystem = new GameResultSystem();
            _numberParticleSystem = new NumberParticleSystem();
            _cardMovementSystem = new CardMovementSystem();
            _transientStateResetSystem = new TransientStateResetSystem();
        }
    }
}
