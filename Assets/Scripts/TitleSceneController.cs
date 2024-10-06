using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class TitleSceneController : MonoBehaviour
    {
        [SerializeField] private Button StartGameButton;
        [SerializeField] private Transform OverCard;
        [SerializeField] private Transform OverCardDestination;
        [SerializeField] private float OverCardDuration;

        private void OnEnable() { StartGameButton.onClick.AddListener(OnStartGameClicked); }

        private void OnDisable() { StartGameButton.onClick.RemoveAllListeners(); }

        private void OnStartGameClicked()
        {
            StartGameButton.onClick.RemoveAllListeners();
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
