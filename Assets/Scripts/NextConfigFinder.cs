namespace GodsExperiment
{
    public static class NextConfigFinder
    {
        private static GameConfigIndex Index => GameConfigIndex.I;

        public static GameConfig Find()
        {
            GameConfig current = GameState.I.Config;
            if (current == null)
                return null;

            for (var i = 0; i < Index.GameConfigs.Length - 1; i++)
                if (current == Index.GameConfigs[i])
                    return Index.GameConfigs[i + 1];

            return null;
        }
    }
}
