using System.Collections.Generic;

namespace GodsExperiment
{
    public static class ResourcePaymentProcessor
    {
        public static bool AttemptPayment(Dictionary<ResourceType, float> resourceCosts, ResourcesState resources)
        {
            foreach ((ResourceType requiredResource, float cost) in resourceCosts)
                if (cost > resources[requiredResource].Count)
                    return false;

            foreach ((ResourceType requiredResource, float cost) in resourceCosts)
                resources[requiredResource].Count -= cost;

            return true;
        }
    }
}
