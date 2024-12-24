using System;
using UnityEngine;

namespace GodsExperiment
{
    [CreateAssetMenu(fileName = "New GameConfig", menuName = "Custom/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: TextArea(minLines: 3, maxLines: 10)]
        [field: SerializeField] public string OpeningMessage { get; private set; }

        [field: SerializeField] public ResourceTarget[] ResourceTargets { get; private set; }
        [field: SerializeField] public int TotalDays { get; private set; }

        [field: SerializeField] public float TimePerDay { get; private set; }
        [field: SerializeField] public int InitialWorkers { get; private set; }
        [field: SerializeField] public int MaxWorkers { get; private set; } // TODO: use this
        [field: SerializeField] public int MaxWorkersPerResource { get; private set; }

        [field: SerializeField] public float DailyWorkerFoodCost { get; private set; }
        [field: SerializeField] public float NewWorkerFoodCost { get; private set; }

        [field: SerializeField] public ResourceRequirementSet[] ResourceRequirementSets { get; private set; }
        [field: SerializeField] public ResourceWorkerSlotsSet[] InitialResourceWorkerSlotsSets { get; private set; }

        [field: SerializeField] public ResourceRequirementSet NewWorkerSlotResourceRequirement { get; private set; }
        [field: SerializeField] public ResourceType[] ResourcesAvailableForConstruction { get; private set; }

        [field: Range(min: 0, max: 1)]
        [field: SerializeField] public float UnworkedResourceDecayRate { get; private set; }

        [field: SerializeField] public string LeaderboardId { get; private set; }

        [Serializable]
        public class ResourceWorkerSlotsSet
        {
            [field: SerializeField] public ResourceType ResourceType { get; private set; }
            [field: SerializeField] public int WorkerSlots { get; private set; }
        }
    }
}
