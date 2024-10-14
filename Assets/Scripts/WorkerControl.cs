using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class WorkerControl : MonoBehaviour
    {
        private static InputState Input => GameState.I.Input;

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

        private void OnAdded()
        {
            Input.WorkerAddPressed = ResourceType;
            Input.WorkerChangeMassModifier =
                UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
        }

        private void OnRemoved()
        {
            Input.WorkerRemovePressed = ResourceType;
            Input.WorkerChangeMassModifier =
                UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
        }
    }
}
