using UnityEngine;

namespace GodsExperiment
{
    public class NumberParticleSystem
    {
        public void Update(ResourcesState resources, UIState uiState)
        {
            foreach (ResourceType resourceType in resources.ResourceTypes)
            {
                ResourceState resource = resources[resourceType];
                if (Mathf.Abs(resource.JustIncreasedBy) > 0.1f)
                    foreach (ResourceGauge gauge in uiState.ResourcesResourceGauges[resourceType])
                        uiState.NumberParticlePool.PlayParticle(
                            number: resource.JustIncreasedBy,
                            startPos: gauge.transform.position
                        );
                if (Mathf.Abs(resource.JustDecreasedBy) > 0.1f)
                    foreach (ResourceGauge gauge in uiState.ResourcesResourceGauges[resourceType])
                        uiState.NumberParticlePool.PlayParticle(
                            number: -resource.JustDecreasedBy,
                            startPos: gauge.transform.position
                        );
            }
        }
    }
}
