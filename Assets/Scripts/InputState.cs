namespace GodsExperiment
{
    public class InputState
    {
        public bool PausePressed { get; set; }
        public bool PlayPressed { get; set; }
        public bool FastForwardPressed { get; set; }
        public bool VeryFastForwardPressed { get; set; }
        public bool AnyPlayButtonPressed => PlayPressed || FastForwardPressed || VeryFastForwardPressed;

        public bool ResetRequested { get; set; }

        public ResourceType WorkerAddPressed { get; set; }
        public ResourceType WorkerRemovePressed { get; set; }
        public bool WorkerChangeMassModifier { get; set; }

        public ResourceType ConstructionRequested { get; set; }
        public bool ConstructionChangeMassModifier { get; set; }

        public string TooltipContent { get; set; } = string.Empty;
    }
}
