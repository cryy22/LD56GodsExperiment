using UnityEngine;

namespace GodsExperiment
{
    public class WorkingAnimator : MonoBehaviour
    {
        private const float _duration = 1f;

        public ResourceType ResourceType { get; set; }
        private float _progress;

        private void Awake() { _progress = Random.Range(minInclusive: 0f, maxInclusive: 1f); }

        private void Update()
        {
            if (ResourceType == ResourceType.None) return;
            if (!GameState.I.Resources[ResourceType].IsPaid) return;

            _progress += GameState.I.Time.DeltaTime * GameState.I.Workers.Productivity / _duration;
            if (_progress > 1)
            {
                SFXPlayer.I.PlaySqueak();
                _progress--;
            }

            float stretch = Mathf.Sin(2 * Mathf.PI * _progress) * 0.125f;
            float squash = -stretch;
            transform.localScale = new Vector3(x: 1 + squash, y: 1 + stretch, z: 1f);
        }
    }
}
