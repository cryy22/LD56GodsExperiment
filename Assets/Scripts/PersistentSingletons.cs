using UnityEngine;

namespace GodsExperiment
{
    public class PersistentSingletons : MonoBehaviour
    {
        private static PersistentSingletons _instance;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
