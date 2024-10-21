using UnityEngine.SceneManagement;

namespace GodsExperiment
{
    public class GameResultSystem
    {
        public void Update(GameState state)
        {
            var hasWon = true;
            foreach (ResourceTarget resourceTarget in state.Config.ResourceTargets)
                if (state.Resources[resourceTarget.ResourceType].Count < resourceTarget.TargetAmount)
                {
                    hasWon = false;
                    break;
                }

            if (hasWon)
                state.GameResult = GameResult.Win;
            else if (state.Time.Day >= state.Config.TotalDays)
                state.GameResult = GameResult.Loss;

            if (state.GameResult != GameResult.None)
                SceneManager.LoadScene("ResultScene");
        }
    }
}
