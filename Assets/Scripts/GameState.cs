using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Custom/Game State")]
    public class GameState : ScriptableObject
    {
        private static GameState _instance;
        public static GameState I =>
            _instance
                ? _instance
                : _instance = UnityEngine.Resources.Load<GameState>("State/GameState");

        public GameConfig Config { get; set; }

        public TimeState Time { get; private set; }
        public ResourcesState Resources { get; private set; }
        public InputState Input { get; private set; }
        public WorkersState Workers { get; private set; }
        public ConstructionState Construction { get; private set; }

        public bool JustBegun { get; set; }
        public GameResult GameResult { get; set; }

        public void ResetAll()
        {
            if (!Config) Config = GameConfigIndex.I.DefaultGameConfig;
            GameResult = GameResult.None;
            JustBegun = true;

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

            var isFoodEnabled = false;
            foreach (ResourceRequirementSet set in Config.ResourceRequirementSets)
                if (set.ResourceType == ResourceType.Food)
                {
                    isFoodEnabled = true;
                    break;
                }

            Workers = new WorkersState(initialWorkers: Config.InitialWorkers, isFoodEnabled: isFoodEnabled)
            {
                DailyWorkerFoodCost = Config.DailyWorkerFoodCost,
                NewWorkerFoodCost = Config.NewWorkerFoodCost,
            };

            Construction = new ConstructionState(
                isEnabled: Config.ResourcesAvailableForConstruction.Length > 0,
                resourceRequirementSet: Config.NewWorkerSlotResourceRequirement
            );
        }
    }
}
