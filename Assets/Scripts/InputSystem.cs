using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class InputSystem
    {
        public void Update(InputState input, UIState uiState)
        {
            bool wasPauseDown = input.PauseDown;

            ResetInputs(input);

            input.PauseDown = Input.GetKeyDown(KeyCode.Space);
            input.PausePressed = input.PauseDown && !wasPauseDown;

            foreach ((ResourceType resourceType, List<WorkerControl> workerControls) in uiState.ResourcesWorkerControls)
            foreach (WorkerControl workerControl in workerControls)
            {
                if (workerControl.AddRequested)
                {
                    input.WorkerAddPressed = resourceType;
                    workerControl.AddRequested = false;
                }

                if (workerControl.RemoveRequested)
                {
                    input.WorkerRemovePressed = resourceType;
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
