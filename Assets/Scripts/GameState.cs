using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Custom/Game State")]
    public class GameState : ScriptableObject
    {
        private static GameState _instance;
        public static GameState I =>
            _instance = _instance ? _instance : UnityEngine.Resources.Load<GameState>("State/GameState");

        [field: SerializeField] public GameConfig DefaultConfig { get; private set; }
        public GameConfig Config { get; set; }

        public TimeState Time { get; private set; }
        public ResourcesState Resources { get; private set; }
        public InputState Input { get; private set; }
        public WorkersState Workers { get; private set; }
        public ConstructionState Construction { get; private set; }

        public GameResult GameResult { get; set; }

        public void ResetAll()
        {
            if (!Config) Config = DefaultConfig;
            GameResult = GameResult.None;

            Time = new TimeState
            {
                TimePerDay = Config.TimePerDay,
            };
            Resources = new ResourcesState(
                requirementSets: Config.ResourceRequirementSets,
                resourceWorkerSlotsSets: Config.InitialResourceWorkerSlotsSets
            )
            {
                UnworkedResourcesDecayRate = Config.UnworkedResourceDecayRate,
            };
            Input = new InputState();
            Workers = new WorkersState(Config.InitialWorkers)
            {
                DailyWorkerFoodCost = Config.DailyWorkerFoodCost,
                NewWorkerFoodCost = Config.NewWorkerFoodCost,
            };
            Construction = new ConstructionState(Config.NewWorkerSlotResourceRequirement);
        }
    }
}
