using UnityEngine;
using UnityEngine.Audio;

namespace GodsExperiment
{
    public class BGMPlayer : MonoBehaviour
    {
        public enum AudioFilterMode
        {
            Unfiltered,
            LowPassed,
        }

        [SerializeField] private AudioSource BGMSource;
        [SerializeField] private AudioMixerSnapshot UnfilteredSnapshot;
        [SerializeField] private AudioMixerSnapshot LowPassedSnapshot;

        public AudioFilterMode FilterMode { get; private set; }

        public void Play()
        {
            BGMSource.Play();
            LowPassedSnapshot.TransitionTo(0.01f);
            FilterMode = AudioFilterMode.LowPassed;
        }

        public void SetFilterMode(AudioFilterMode mode)
        {
            if (FilterMode == mode) return;
            FilterMode = mode;

            switch (mode)
            {
                case AudioFilterMode.LowPassed:
                    LowPassedSnapshot.TransitionTo(0.1f);
                    break;
                case AudioFilterMode.Unfiltered:
                default:
                    UnfilteredSnapshot.TransitionTo(0.1f);
                    break;
            }
        }
    }
}
