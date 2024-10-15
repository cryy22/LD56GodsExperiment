using UnityEngine;

namespace GodsExperiment
{
    public class InputSystem
    {
        public void Update(InputState input)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha0))
                input.PausePressed = true;
            else if (Input.GetKeyDown(KeyCode.Alpha1))
                input.PlayPressed = true;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                input.FastForwardPressed = true;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                input.VeryFastForwardPressed = true;
        }
    }
}
