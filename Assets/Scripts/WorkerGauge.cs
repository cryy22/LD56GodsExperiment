using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class WorkerGauge : MonoBehaviour
    {
        [SerializeField] private Transform WorkerParent;
        [SerializeField] private WorkerSlot WorkerPrefab;

        private readonly List<WorkerSlot> _slots = new();

        private void Start()
        {
            foreach (Transform child in WorkerParent)
                Destroy(child.gameObject);
        }

        public void SetSlots(int count)
        {
            while (_slots.Count < count)
            {
                WorkerSlot slot = Instantiate(original: WorkerPrefab, parent: transform);
                slot.SetOccupied(false);
                _slots.Add(slot);
            }

            while (_slots.Count > count)
            {
                WorkerSlot slot = _slots[^1];
                Destroy(slot.gameObject);
                _slots.Remove(slot);
            }
        }

        public void SetWorkers(int count)
        {
            for (var i = 0; i < _slots.Count; i++) _slots[i].SetOccupied(count > i);
        }
    }
}
