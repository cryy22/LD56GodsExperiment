using System;
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

        [SerializeField] private Transform GameStartOptionsParent;

        [SerializeField] private GameStartButton GameStartButtonPrefab;

        private void Start()
        {
            foreach (Transform child in GameStartOptionsParent)
                Destroy(child.gameObject);

            foreach (GameConfig config in GameConfigIndex.I.GameConfigs)
            {
                GameStartButton button = Instantiate(original: GameStartButtonPrefab, parent: GameStartOptionsParent);
                button.Initialize(config);
                button.Pressed += OnStartGameClicked;
            }
        }

        private void OnStartGameClicked(object sender, EventArgs e) { StartCoroutine(RunLoadScene()); }

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
