using UnityEngine;

namespace GodsExperiment
{
    public class TimeControl : MonoBehaviour
    {
        private static TimeState Time => GameState.I.Time;
        private static InputState Input => GameState.I.Input;

        [SerializeField] private HoverButton PauseButton;
        [SerializeField] private HoverButton PlayButton;
        [SerializeField] private HoverButton FastForwardButton;
        [SerializeField] private HoverButton VeryFastForwardButton;

        private void Update()
        {
            PauseButton.targetGraphic.color =
                Time.IsTimePaused
                    ? Constants.Yellow
                    : Constants.LightGray;
            PlayButton.targetGraphic.color =
                !Time.IsTimePaused && Mathf.Approximately(a: Time.TimeSpeed, b: Constants.PlaySpeed)
                    ? Constants.Yellow
                    : Constants.LightGray;
            FastForwardButton.targetGraphic.color =
                !Time.IsTimePaused && Mathf.Approximately(a: Time.TimeSpeed, b: Constants.FastForwardSpeed)
                    ? Constants.Yellow
                    : Constants.LightGray;
            VeryFastForwardButton.targetGraphic.color =
                !Time.IsTimePaused && Mathf.Approximately(a: Time.TimeSpeed, b: Constants.VeryFastForwardSpeed)
                    ? Constants.Yellow
                    : Constants.LightGray;

            PauseButton.transform.localScale = Vector3.one * (PauseButton.IsHovered ? 1.1f : 1f);
            PlayButton.transform.localScale = Vector3.one * (PlayButton.IsHovered ? 1.1f : 1f);
            FastForwardButton.transform.localScale = Vector3.one * (FastForwardButton.IsHovered ? 1.1f : 1f);
            VeryFastForwardButton.transform.localScale = Vector3.one * (VeryFastForwardButton.IsHovered ? 1.1f : 1f);
        }

        private void OnEnable()
        {
            PauseButton.onClick.AddListener(OnPauseSelected);
            PlayButton.onClick.AddListener(OnPlaySelected);
            FastForwardButton.onClick.AddListener(OnFastForwardSelected);
            VeryFastForwardButton.onClick.AddListener(OnVeryFastForwardSelected);
        }

        private void OnDisable()
        {
            PauseButton.onClick.RemoveListener(OnPauseSelected);
            PlayButton.onClick.RemoveListener(OnPlaySelected);
            FastForwardButton.onClick.RemoveListener(OnFastForwardSelected);
            VeryFastForwardButton.onClick.RemoveListener(OnVeryFastForwardSelected);
        }

        private void OnPauseSelected() { Input.PausePressed = true; }
        private void OnPlaySelected() { Input.PlayPressed = true; }
        private void OnFastForwardSelected() { Input.FastForwardPressed = true; }
        private void OnVeryFastForwardSelected() { Input.VeryFastForwardPressed = true; }
    }
}
