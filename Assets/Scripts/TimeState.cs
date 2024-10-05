namespace GodsExperiment
{
    public class TimeState
    {
        public float Time { get; set; } = 0;
        public float DeltaTime { get; set; } = 0;
        public float TimeSpeed { get; set; } = 1;
        public bool IsTimePaused { get; set; } = true;
    }
}
