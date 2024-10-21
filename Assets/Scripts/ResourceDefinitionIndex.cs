using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "ResourceDefinitionIndex", menuName = "Custom/Resource Definition Index")]
    public class ResourceDefinitionIndex : ScriptableObject
    {
        private static ResourceDefinitionIndex _instance;
        public static ResourceDefinitionIndex I =>
            _instance
                ? _instance
                : _instance = Resources.Load<ResourceDefinitionIndex>("Indexes/ResourceDefinitionIndex");

        [field: SerializeField] public ResourceDefinition[] ResourceDefinitions { get; private set; }

        public Sprite GetSpriteForResource(ResourceType resourceType)
        {
            foreach (ResourceDefinition definition in ResourceDefinitions)
                if (definition.ResourceType == resourceType)
                    return definition.Icon;

            return null;
        }

        public string GetNameForResource(ResourceType resourceType)
        {
            foreach (ResourceDefinition definition in ResourceDefinitions)
                if (definition.ResourceType == resourceType)
                    return definition.Name;

            return "resource";
        }

        public Color GetColorForResource(ResourceType resourceType)
        {
            foreach (ResourceDefinition definition in ResourceDefinitions)
                if (definition.ResourceType == resourceType)
                    return definition.Color;

            return Color.white;
        }
    }
}
