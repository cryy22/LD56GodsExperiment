using System;
using UnityEngine;

namespace GodsExperiment
{
    [Serializable]
    public class ResourceDefinition
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Color Color { get; private set; }
    }
}
