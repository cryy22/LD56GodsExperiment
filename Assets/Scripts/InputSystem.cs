using UnityEngine;

namespace GodsExperiment
{
    public class InputSystem
    {
        public void Update(InputState state)
        {
            var isPauseDown = Input.GetKeyDown(KeyCode.Space);
            
            state.PausePressed = isPauseDown && !state.PauseDown;
            state.PauseDown = isPauseDown;
        }
    }
}
