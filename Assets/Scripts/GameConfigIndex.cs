using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "GameConfigIndex", menuName = "Custom/Game Config Index")]
    public class GameConfigIndex : ScriptableObject
    {
        [SerializeField] private GameConfig[] GameConfigsInput;
        public IEnumerable<GameConfig> GameConfigs => GameConfigsInput;
    }
}
