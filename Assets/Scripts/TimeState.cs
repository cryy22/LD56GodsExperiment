namespace GodsExperiment
{
    public class TimeState
    {
        public float Time { get; set; } = 0;
        public float DeltaTime { get; set; } = 0;
        public int Day { get; set; } = 0;
        public bool DayChanged { get; set; } = true;
        public float TimePerDay { get; set; } = 999f;
        public float TimeSpeed { get; set; } = 1;
        public bool IsTimePaused { get; set; } = true;

        public float DayProgress => Time / TimePerDay;
    }
}
