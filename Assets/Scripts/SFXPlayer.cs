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

        public void PlaySqueak() { AudioSource.PlayOneShot(SqueakClip); }
    }
}
