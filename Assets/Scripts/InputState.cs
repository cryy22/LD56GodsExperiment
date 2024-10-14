namespace GodsExperiment
{
    public class InputState
    {
        public bool PausePressed { get; set; }
        public bool PauseDown { get; set; }
        public bool ResetRequested { get; set; }

        public ResourceType WorkerAddPressed { get; set; }
        public ResourceType WorkerRemovePressed { get; set; }
        public bool WorkerChangeMassModifier { get; set; }

        public ResourceType ConstructionRequested { get; set; }
        public bool ConstructionChangeMassModifier { get; set; }

        public string TooltipContent { get; set; } = string.Empty;
    }
}
