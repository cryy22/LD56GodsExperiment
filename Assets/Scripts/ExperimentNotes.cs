using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ExperimentNotes : MonoBehaviour
    {
        [SerializeField] private Transform NotesCard;
        [SerializeField] private Button ShowHideButton;
        [SerializeField] private TMP_Text ShowHideButtonText;
        [SerializeField] private float ShowHideDuration = 0.5f;

        [SerializeField] private Vector2 OffscreenPoint;
        [SerializeField] private Vector2 OnscreenPoint;

        private bool _isShown;
        private bool _isMoving;
        private Vector3 _destination = Vector3.zero;
        private Vector3 _startPosition = Vector3.zero;
        private float _progress;

        private void Awake() { NotesCard.localPosition = OffscreenPoint; }

        private void Update()
        {
            if (!_isMoving) return;

            _progress += Time.deltaTime / ShowHideDuration;
            NotesCard.localPosition = Vector3.Lerp(a: _startPosition, b: _destination, t: _progress);
            if (_progress >= 1)
                _isMoving = false;
        }

        private void OnEnable() { ShowHideButton.onClick.AddListener(OnShowHideButtonClicked); }
        private void OnDisable() { ShowHideButton.onClick.RemoveListener(OnShowHideButtonClicked); }

        private void OnShowHideButtonClicked()
        {
            if (!_isShown)
            {
                _isShown = true;
                _destination = OnscreenPoint;
                ShowHideButtonText.text = "hide experiment notes";
            }
            else
            {
                _isShown = false;
                _destination = OffscreenPoint;
                ShowHideButtonText.text = "show experiment notes";
            }

            _isMoving = true;
            _progress = 0f;
            _startPosition = NotesCard.localPosition;
        }
    }
}
