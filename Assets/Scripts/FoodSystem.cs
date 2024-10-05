namespace GodsExperiment
{
    public class FoodSystem
    {
        public void Update(TimeState time, ResourceState food, WorkersState workers)
        {
            if (!time.DayChanged)
                return;

            food.Count -= workers.TotalDailyFoodCost;
        }
    }
}
