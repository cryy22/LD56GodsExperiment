using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class SFXPlayer : MonoBehaviour
    {
        private const int _maxVoices = 63;
        public static SFXPlayer I { get; private set; }

        [SerializeField] private AudioClip SqueakClip;
        [SerializeField] private AudioSource AudioSource;

        private readonly List<float> _activeVoices = new(_maxVoices);

        public void Awake()
        {
            if (I != null)
            {
                Destroy(gameObject);
                return;
            }

            I = this;
        }

        private void Update()
        {
            for (var i = 0; i < _activeVoices.Count; i++)
                _activeVoices[i] -= Time.deltaTime;

            while ((_activeVoices.Count > 0) && (_activeVoices[0] <= 0))
                _activeVoices.RemoveAt(0);
        }

        public void PlaySqueak()
        {
            if (_activeVoices.Count >= _maxVoices)
                return;

            AudioSource.pitch = Random.Range(minInclusive: 0.8f, maxInclusive: 1.2f);
            AudioSource.PlayOneShot(SqueakClip);
            _activeVoices.Add(SqueakClip.length);
        }
    }
}
