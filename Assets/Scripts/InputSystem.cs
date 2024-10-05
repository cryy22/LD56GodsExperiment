using UnityEngine;

namespace GodsExperiment
{
    public class InputSystem
    {
        public void Update(InputState state, UIState uiState)
        {
            bool wasPauseDown = state.PauseDown;

            ResetInputs(state);

            state.PauseDown = Input.GetKeyDown(KeyCode.Space);
            state.PausePressed = state.PauseDown && !wasPauseDown;

            foreach (UIState.ResourceToWorkerControlMap workerControlMap in uiState.WorkerControls)
            {
                if (workerControlMap.WorkerControl.AddRequested)
                {
                    state.WorkerAddPressed = workerControlMap.ResourceType;
                    workerControlMap.WorkerControl.AddRequested = false;
                }

                if (workerControlMap.WorkerControl.RemoveRequested)
                {
                    state.WorkerRemovePressed = workerControlMap.ResourceType;
                    workerControlMap.WorkerControl.RemoveRequested = false;
                }
            }
        }

        private void ResetInputs(InputState state)
        {
            state.PauseDown = false;
            state.PausePressed = false;
            state.WorkerAddPressed = ResourceType.None;
            state.WorkerRemovePressed = ResourceType.None;
        }
    }
}
