using UnityEngine;

namespace GodsExperiment
{
    public class WorkerSlot : MonoBehaviour
    {
        [field: SerializeField] public WorkingAnimator Animator { get; private set; }

        [SerializeField] private GameObject WorkerImage;

        public void SetOccupied(bool occupied) { WorkerImage.SetActive(occupied); }
    }
}
