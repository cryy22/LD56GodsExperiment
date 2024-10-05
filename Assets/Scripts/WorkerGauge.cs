using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class WorkerGauge : MonoBehaviour
    {
        private const int _maxSize = 8;

        [SerializeField] private Transform WorkerParent;
        [SerializeField] private GameObject WorkerPrefab;

        private readonly List<GameObject> _workers = new(_maxSize);

        private void Start()
        {
            foreach (Transform child in WorkerParent)
                Destroy(child.gameObject);
        }

        public void SetCount(int count)
        {
            count = Mathf.Clamp(value: count, min: 0, max: _maxSize);

            while (_workers.Count < count)
            {
                GameObject worker = Instantiate(original: WorkerPrefab, parent: transform);
                _workers.Add(worker);
            }

            while (_workers.Count > count)
            {
                GameObject worker = _workers[-1];
                Destroy(worker);
                _workers.Remove(worker);
            }
        }
    }
}
