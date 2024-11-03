using UnityEngine;

namespace GodsExperiment
{
    public class CardMovementSystem
    {
        private bool _isMoving;
        private float _progress;

        public void Update(GameState state, UIState uiState)
        {
            if (state.JustBegun)
                _isMoving = true;

            if (!_isMoving)
                return;

            _progress += Time.deltaTime / uiState.CoveringCardMoveDuration;
            uiState.CoveringCardTransform.position = Vector3.Lerp(
                a: uiState.CoveringCardOnscreenPosition,
                b: uiState.CoveringCardOffscreenPosition,
                t: _progress
            );
            if (_progress >= 1)
                _isMoving = false;
        }
    }
}
