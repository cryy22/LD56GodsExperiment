using UnityEngine;

namespace GodsExperiment
{
    public class SFXPlayer : MonoBehaviour
    {
        public static SFXPlayer I { get; private set; }

        [SerializeField] private AudioClip SqueakClip;
        [SerializeField] private AudioSource AudioSource;

        public void Awake()
        {
            if (I != null)
            {
                Destroy(gameObject);
                return;
            }

            I = this;
        }

        public void PlaySqueak()
        {
            AudioSource.pitch = Random.Range(minInclusive: 0.925f, maxInclusive: 1.075f);
            AudioSource.PlayOneShot(SqueakClip);
        }
    }
}
