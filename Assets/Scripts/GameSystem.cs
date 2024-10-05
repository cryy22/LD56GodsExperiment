using UnityEngine;

namespace GodsExperiment
{
    public class GameSystem : MonoBehaviour
    {
        private GameTimeSystem _gameTimeSystem;
        private ResourceProgressSystem _resourceProgressSystem;
        
        private static GameState State => GameState.I;

        private void Start()
        {
            _gameTimeSystem = new GameTimeSystem();
            _resourceProgressSystem = new ResourceProgressSystem();
        }

        private void Update()
        {
            _gameTimeSystem.Update(State.TimeState);
            _resourceProgressSystem.Update(State.TimeState, State.ResourceState);
        }
    }
}
