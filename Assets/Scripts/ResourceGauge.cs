using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ResourceGauge : MonoBehaviour
    {
        private const float _flashDuration = 0.125f;

        [SerializeField] private TMP_Text CountText;
        [SerializeField] private Image IconImage;
        [SerializeField] private ProgressBar ProgressBar;

        private float _previousCount;

        private Color _initialColor;
        private bool _isFlashing;
        private float _flashProgress;
        private Color _flashColor;

        private void Awake() { _initialColor = CountText.color; }

        private void Update()
        {
            if (_isFlashing)
            {
                _flashProgress += GameState.I.Time.DeltaTime / _flashDuration;
                if (_flashProgress >= 1)
                {
                    _isFlashing = false;
                    CountText.color = _initialColor;
                }
                else
                {
                    CountText.color = Color.Lerp(a: _flashColor, b: _initialColor, t: _flashProgress);
                }
            }
        }

        public void SetIcon(Sprite icon)
        {
            IconImage.sprite = icon;
            IconImage.color = icon ? Color.white : Color.clear;
        }

        public void SetColor(Color color) { ProgressBar.SetColor(color); }
        public void ShowCountText(bool show) { CountText.gameObject.SetActive(show); }

        public void SetValues(float count, float progress)
        {
            CountText.text = ((int) count).ToString();
            ProgressBar.SetProgress(progress);

            if (!Mathf.Approximately(a: _previousCount, b: count))
            {
                _isFlashing = true;
                _flashProgress = 0f;

                _flashColor = count < _previousCount
                    ? Constants.Red
                    : Constants.Green;
            }

            _previousCount = count;
        }
    }
}
