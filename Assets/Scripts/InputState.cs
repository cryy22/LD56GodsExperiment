namespace GodsExperiment
{
    public class InputState
    {
        public bool PausePressed { get; set; }
        public bool PauseDown { get; set; }
        public bool ResetRequested { get; set; }

        public ResourceType WorkerAddPressed;
        public ResourceType WorkerRemovePressed;
        public ResourceType ConstructionRequested;
    }
}
