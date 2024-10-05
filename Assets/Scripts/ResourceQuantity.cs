using System;
using UnityEngine;

namespace GodsExperiment
{
    [Serializable]
    public class ResourceQuantity
    {
        [field: SerializeField] public ResourceType Resource { get; private set; }
        [field: SerializeField] public int Quantity { get; private set; }
    }
}
