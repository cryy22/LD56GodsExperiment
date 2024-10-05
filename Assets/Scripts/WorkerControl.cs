using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class WorkerControl : MonoBehaviour
    {
        [SerializeField] private Button WorkerAddButton;
        [SerializeField] private Button WorkerRemoveButton;

        public bool AddRequested { get; set; }
        public bool RemoveRequested { get; set; }

        private void Start()
        {
            WorkerAddButton.onClick.AddListener(() => AddRequested = true);
            WorkerRemoveButton.onClick.AddListener(() => RemoveRequested = true);
        }
    }
}
