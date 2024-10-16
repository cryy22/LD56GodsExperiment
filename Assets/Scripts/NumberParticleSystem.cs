using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class NumberParticleSystem
    {
        private readonly Dictionary<ResourceType, float> _lastResourceCounts = new();

        public void Update(ResourcesState resources, UIState uiState)
        {
            foreach (ResourceType resourceType in resources.ResourceTypes)
            {
                float current = resources[resourceType].Count;
                if (_lastResourceCounts.TryGetValue(key: resourceType, value: out float last))
                {
                    float delta = current - last;
                    if (Mathf.Abs(delta) > 0.1f)

                        foreach (ResourceGauge gauge in uiState.ResourcesResourceGauges[resourceType])
                            uiState.NumberParticlePool.PlayParticle(number: delta, startPos: gauge.transform.position);
                }

                _lastResourceCounts[resourceType] = current;
            }
        }
    }
}
