using UnityEngine;

namespace GodsExperiment
{
    public class OpeningCardSystem
    {
        private enum OpeningCardMode
        {
            Displayed,
            Dismissing,
            Dismissed,
        }

        private OpeningCardMode _mode;
        private float _progress;

        public void Update(GameState state, UIState uiState)
        {
            if (state.JustBegun)
            {
                _mode = OpeningCardMode.Displayed;
                uiState.CoveringCardTransform.position = uiState.CoveringCardOnscreenPosition;
            }

            if (state.Input.OpeningCardDismissRequested)
            {
                _mode = OpeningCardMode.Dismissing;
                _progress = 0;
            }

            if (_mode == OpeningCardMode.Dismissing)
            {
                _progress += Time.deltaTime / uiState.CoveringCardMoveDuration;
                uiState.CoveringCardTransform.position = Vector3.Lerp(
                    a: uiState.CoveringCardOnscreenPosition,
                    b: uiState.CoveringCardOffscreenPosition,
                    t: _progress
                );
                if (_progress >= 1)
                    _mode = OpeningCardMode.Dismissed;
            }
        }
    }
}
