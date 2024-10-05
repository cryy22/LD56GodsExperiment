using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "New GameConfig", menuName = "Custom/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public float TimePerDay { get; private set; }
        [field: SerializeField] public int InitialWorkers { get; private set; }
        [field: SerializeField] public ResourceDefinition[] ResourceDefinitions { get; private set; }
        [field: SerializeField] public ResourceRequirementSet[] ResourceRequirementSets { get; private set; }

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
