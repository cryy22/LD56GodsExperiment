using UnityEngine;

namespace GodsExperiment
{
    public class InputSystem
    {
        public void Update(InputState input)
        {
            bool wasPauseDown = input.PauseDown;

            ResetInputs(input);

            input.PauseDown = Input.GetKeyDown(KeyCode.Space);
            input.PausePressed = input.PauseDown && !wasPauseDown;
        }

        private void ResetInputs(InputState state)
        {
            state.PauseDown = false;
            state.PausePressed = false;
        }
    }
}
