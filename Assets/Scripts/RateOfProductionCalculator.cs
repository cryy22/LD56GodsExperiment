namespace GodsExperiment
{
    public static class RateOfProductionCalculator
    {
        public static float CalculatePerDay(WorkersState workers, ResourceState resource, TimeState time)
        {
            return
                workers[resource.Type] * workers.Productivity * time.TimePerDay // work units per day
                * resource.WorkUnitsPerUnit;
        }
    }
}
