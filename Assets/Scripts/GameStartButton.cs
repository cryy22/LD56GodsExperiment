using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class GameStartButton : MonoBehaviour
    {
        public event EventHandler Pressed;

        [SerializeField] private Button Button;
        [SerializeField] private TMP_Text ButtonText;

        public GameConfig TargetConfig { get; private set; }

        private void OnEnable() { Button.onClick.AddListener(OnPressed); }
        private void OnDisable() { Button.onClick.RemoveListener(OnPressed); }

        public void Initialize(GameConfig config)
        {
            TargetConfig = config;
            ButtonText.text = config.Name;
        }

        private void OnPressed()
        {
            GameState.I.Config = TargetConfig;
            Pressed?.Invoke(sender: this, e: EventArgs.Empty);
        }
    }
}
