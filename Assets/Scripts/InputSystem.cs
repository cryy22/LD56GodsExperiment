using System.Collections.Generic;
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

            foreach ((ResourceType resourceType, List<WorkerControl> workerControls) in uiState.ResourcesWorkerControls)
            foreach (WorkerControl workerControl in workerControls)
            {
                if (workerControl.AddRequested)
                {
                    state.WorkerAddPressed = resourceType;
                    workerControl.AddRequested = false;
                }

                if (workerControl.RemoveRequested)
                {
                    state.WorkerRemovePressed = resourceType;
                    workerControl.RemoveRequested = false;
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
