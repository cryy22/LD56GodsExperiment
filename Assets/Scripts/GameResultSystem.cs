using UnityEngine.SceneManagement;

namespace GodsExperiment
{
    public class GameResultSystem
    {
        public void Update(GameState state)
        {
            if (state.Resources[ResourceType.Boos].Count >= state.Config.TotalBoosTarget)
                state.GameResult = GameResult.Win;
            else if (state.Time.Day >= state.Config.TotalDays)
                state.GameResult = GameResult.Loss;

            if (state.GameResult != GameResult.None)
                SceneManager.LoadScene("ResultScene");
        }
    }
}
