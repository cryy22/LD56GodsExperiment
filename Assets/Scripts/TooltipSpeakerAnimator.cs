using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class TooltipSpeakerAnimator : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sprites;
        [SerializeField] private Image Image;
        [SerializeField] private float FrameSpeed = 0.5f;

        private bool _isRunning;
        private int _spriteIndex;
        private float _timeToSwap;

        private void Update()
        {
            if (!_isRunning)
                return;

            _timeToSwap -= Time.deltaTime;
            if (_timeToSwap < 0)
            {
                _timeToSwap += FrameSpeed;
                _spriteIndex = (_spriteIndex + 1) % Sprites.Length;
                Image.sprite = Sprites[_spriteIndex];
            }
        }

        public void Run()
        {
            _isRunning = true;

            _spriteIndex = 0;
            Image.sprite = Sprites[0];
            _timeToSwap = FrameSpeed;
        }

        public void Stop()
        {
            _isRunning = false;
            _spriteIndex = 0;
            Image.sprite = Sprites[0];
        }
    }
}
