using UnityEngine;

namespace GodsExperiment
{
    public class WorkingSoundPlayer : MonoBehaviour
    {
        private const float _duration = 1f;
        private float _progress;

        private void Awake() { _progress = Random.Range(minInclusive: 0f, maxInclusive: 1f); }

        private void Update()
        {
            _progress += GameState.I.Time.DeltaTime * GameState.I.Workers.Productivity / _duration;
            if (_progress > 1)
            {
                Debug.Log("whoa");
                SFXPlayer.I.PlaySqueak();
                _progress--;
            }
        }
    }
}
