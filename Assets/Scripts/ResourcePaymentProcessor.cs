using System.Collections.Generic;

namespace GodsExperiment
{
    public static class ResourcePaymentProcessor
    {
        public static bool CheckIfPayable(Dictionary<ResourceType, float> resourceCosts, ResourcesState resources)
        {
            foreach ((ResourceType requiredResource, float cost) in resourceCosts)
                if (cost > resources[requiredResource].Count)
                    return false;

            return true;
        }

        public static bool AttemptPayment(Dictionary<ResourceType, float> resourceCosts, ResourcesState resources)
        {
            bool payable = CheckIfPayable(resourceCosts: resourceCosts, resources: resources);
            if (payable)
                foreach ((ResourceType requiredResource, float cost) in resourceCosts)
                    resources[requiredResource].Count -= cost;

            return payable;
        }

        public static void RefundPayment(Dictionary<ResourceType, float> resourceCosts, ResourcesState resources)
        {
            foreach ((ResourceType requiredResource, float cost) in resourceCosts)
                resources[requiredResource].AdjustValue(cost);
        }
    }
}
