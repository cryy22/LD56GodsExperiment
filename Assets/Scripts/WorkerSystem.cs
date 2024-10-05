namespace GodsExperiment
{
    public class WorkerSystem
    {
        public void Update(WorkersState workers, InputState input)
        {
            if (input.WorkerAddPressed != ResourceType.None)
                if ((workers[ResourceType.None] > 0) && (workers[input.WorkerAddPressed] < Constants.MaxWorkersPerTask))
                {
                    workers[input.WorkerAddPressed] += 1;
                    workers[ResourceType.None] -= 1;
                }

            if (input.WorkerRemovePressed != ResourceType.None)
                if (workers[input.WorkerRemovePressed] > 0)
                {
                    workers[input.WorkerRemovePressed] -= 1;
                    workers[ResourceType.None] += 1;
                }
        }
    }
}
