using UnityEngine;

namespace GodsExperiment
{
    public class WorkerSlot : MonoBehaviour
    {
        [SerializeField] private GameObject WorkerImage;

        public void SetOccupied(bool occupied) { WorkerImage.SetActive(occupied); }
    }
}
