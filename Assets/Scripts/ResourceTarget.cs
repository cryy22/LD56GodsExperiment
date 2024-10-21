using System;
using UnityEngine;

namespace GodsExperiment
{
    [Serializable]
    public class ResourceTarget
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public int TargetAmount { get; private set; }
    }
}
