using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ResultSceneController : MonoBehaviour
    {
        [SerializeField] private TMP_Text ResultDescriptionText;
        [SerializeField] private Image ResultImage;
        [SerializeField] private Sprite WinSprite;
        [SerializeField] private Sprite LoseSprite;

        [SerializeField] private Button RetryButton;
        [SerializeField] private Button TitleButton;
        [SerializeField] private GameObject NextTrialLabel;
        [SerializeField] private Button NextTrialButton;
        [SerializeField] private TMP_Text NextTrialButtonText;

        [SerializeField] private Transform OverCard;
        [SerializeField] private Transform OverCardDestination;
        [SerializeField] private float OverCardDuration;

        private GameConfig _nextTrialConfig;

        private void Start()
        {
            ResultDescriptionText.text = GameState.I.GameResult == GameResult.Win
                ? "EXPERIMENT: SUCCESS!"
                : "EXPERIMENT: FAIL";
            ResultDescriptionText.color = GameState.I.GameResult == GameResult.Win
                ? Constants.Green
                : Constants.Red;
            ResultImage.sprite = GameState.I.GameResult == GameResult.Win
                ? WinSprite
                : LoseSprite;

            var shouldShowNextTrial = false;
            if (GameState.I.GameResult == GameResult.Win)
            {
                _nextTrialConfig = NextConfigFinder.Find();
                if (_nextTrialConfig)
                    shouldShowNextTrial = true;
            }

            NextTrialLabel.SetActive(shouldShowNextTrial);
            NextTrialButton.gameObject.SetActive(shouldShowNextTrial);
            if (shouldShowNextTrial)
                NextTrialButtonText.text = _nextTrialConfig.Name;
        }

        private void OnEnable() { AddListeners(); }
        private void OnDisable() { RemoveListeners(); }

        private void AddListeners()
        {
            RetryButton.onClick.AddListener(OnRetryClicked);
            TitleButton.onClick.AddListener(OnTitleClicked);
            NextTrialButton.onClick.AddListener(OnNextTrialClicked);
        }

        private void RemoveListeners()
        {
            RetryButton.onClick.RemoveAllListeners();
            TitleButton.onClick.RemoveAllListeners();
            NextTrialButton.onClick.RemoveAllListeners();
        }

        private void OnRetryClicked()
        {
            RemoveListeners();
            StartCoroutine(RunLoadScene("GameScene"));
        }

        private void OnTitleClicked()
        {
            RemoveListeners();
            StartCoroutine(RunLoadScene("TitleScene"));
        }

        private void OnNextTrialClicked()
        {
            RemoveListeners();
            GameState.I.Config = _nextTrialConfig;
            StartCoroutine(RunLoadScene("GameScene"));
        }

        private IEnumerator RunLoadScene(string sceneName)
        {
            float t = 0;
            Vector3 startPos = OverCard.position;

            while (t < 1)
            {
                t += Time.deltaTime / OverCardDuration;
                OverCard.position = Vector3.Lerp(a: startPos, b: OverCardDestination.position, t: t);
                yield return null;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}
