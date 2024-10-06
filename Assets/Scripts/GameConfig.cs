using System;
using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "New GameConfig", menuName = "Custom/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public int TotalBoosTarget;
        [field: SerializeField] public int TotalDays;

        [field: SerializeField] public float TimePerDay { get; private set; }
        [field: SerializeField] public int InitialWorkers { get; private set; }
        [field: SerializeField] public int MaxWorkers { get; private set; }
        [field: SerializeField] public int MaxWorkersPerResource { get; private set; }

        [field: SerializeField] public float DailyWorkerFoodCost { get; private set; }
        [field: SerializeField] public float NewWorkerFoodCost { get; private set; }

        [field: SerializeField] public ResourceDefinition[] ResourceDefinitions { get; private set; }
        [field: SerializeField] public ResourceRequirementSet[] ResourceRequirementSets { get; private set; }
        [field: SerializeField] public ResourceWorkerSlotsSet[] InitialResourceWorkerSlotsSets { get; private set; }

        [field: SerializeField] public ResourceRequirementSet NewWorkerSlotResourceRequirement { get; private set; }
        [field: SerializeField] public ResourceType[] ResourcesAvailableForConstruction { get; private set; }

        [field: Range(min: 0, max: 1)]
        [field: SerializeField] public float UnworkedResourceDecayRate { get; private set; }

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

        [Serializable]
        public class ResourceWorkerSlotsSet
        {
            [field: SerializeField] public ResourceType ResourceType { get; private set; }
            [field: SerializeField] public int WorkerSlots { get; private set; }
        }
    }
}
