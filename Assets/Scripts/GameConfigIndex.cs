using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameConfigIndex", menuName = "Custom/Game Config Index")]
    public class GameConfigIndex : ScriptableObject
    {
        private static GameConfigIndex _instance;
        public static GameConfigIndex I =>
            _instance
                ? _instance
                : _instance = Resources.Load<GameConfigIndex>("Indexes/GameConfigIndex");

        [field: SerializeField] public GameConfig[] GameConfigs { get; private set; }
    }
}
