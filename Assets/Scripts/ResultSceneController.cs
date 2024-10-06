using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ResultSceneController : MonoBehaviour
    {
        [SerializeField] private Image ResultImage;
        [SerializeField] private Sprite WinSprite;
        [SerializeField] private Sprite LoseSprite;

        [SerializeField] private Button RetryButton;
        [SerializeField] private Transform OverCard;
        [SerializeField] private Transform OverCardDestination;
        [SerializeField] private float OverCardDuration;

        private void Start() { ResultImage.sprite = GameState.I.GameResult == GameResult.Win ? WinSprite : LoseSprite; }

        private void OnEnable() { RetryButton.onClick.AddListener(OnRetryClicked); }
        private void OnDisable() { RetryButton.onClick.RemoveAllListeners(); }

        private void OnRetryClicked()
        {
            RetryButton.onClick.RemoveAllListeners();
            StartCoroutine(RunLoadScene());
        }

        private IEnumerator RunLoadScene()
        {
            float t = 0;
            Vector3 startPos = OverCard.position;

            while (t < 1)
            {
                t += Time.deltaTime / OverCardDuration;
                OverCard.position = Vector3.Lerp(a: startPos, b: OverCardDestination.position, t: t);
                yield return null;
            }

            SceneManager.LoadScene("GameScene");
        }
    }
}
