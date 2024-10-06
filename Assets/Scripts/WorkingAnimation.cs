using UnityEngine;

namespace GodsExperiment
{
    public class WorkingAnimation : MonoBehaviour
    {
        private const float _duration = 1f;
        private float _progress;

        private void Update()
        {
            _progress += GameState.I.Time.DeltaTime * GameState.I.Workers.Productivity / _duration;
            if (_progress > 1)
            {
                _progress--;
                SFXPlayer.I.PlaySqueak();
            }

            float stretch = Mathf.Sin(2 * Mathf.PI * _progress) * 0.125f;
            float squash = -stretch;
            transform.localScale = new Vector3(x: 1 + squash, y: 1 + stretch, z: 1f);
        }
    }
}
