using System;
using UnityEngine;

namespace GodsExperiment
{
    [Serializable]
    public class ResourceRequirements
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public float WorkUnits { get; set; }
        [field: SerializeField] public ResourceQuantity[] RequiredResources { get; set; }
    }
}