using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class WorkerControl : MonoBehaviour
    {
        [SerializeField] private Button WorkerAddButton;
        [SerializeField] private Button WorkerRemoveButton;

        [field: SerializeField] public WorkerGauge Gauge { get; private set; }

        public ResourceType ResourceType { get; set; }

        private void OnEnable()
        {
            WorkerAddButton.onClick.AddListener(OnAdded);
            WorkerRemoveButton.onClick.AddListener(OnRemoved);
        }

        private void OnDisable()
        {
            WorkerAddButton.onClick.RemoveAllListeners();
            WorkerRemoveButton.onClick.RemoveAllListeners();
        }

        private void OnAdded() { GameState.I.Input.WorkerAddPressed = ResourceType; }
        private void OnRemoved() { GameState.I.Input.WorkerRemovePressed = ResourceType; }
    }
}
