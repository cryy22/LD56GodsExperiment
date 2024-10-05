using System.Collections.Generic;
using UnityEngine;

namespace GodsExperiment
{
    public class WorkerGauge : MonoBehaviour
    {
        [SerializeField] private Transform WorkerParent;
        [SerializeField] private GameObject WorkerPrefab;

        private readonly List<GameObject> _workers = new(Constants.MaxWorkersPerResource);

        private void Start()
        {
            foreach (Transform child in WorkerParent)
                Destroy(child.gameObject);
        }

        public void SetCount(int count)
        {
            count = Mathf.Clamp(value: count, min: 0, max: Constants.MaxWorkersPerResource);

            while (_workers.Count < count)
            {
                GameObject worker = Instantiate(original: WorkerPrefab, parent: transform);
                _workers.Add(worker);
            }

            while (_workers.Count > count)
            {
                GameObject worker = _workers[^1];
                Destroy(worker);
                _workers.Remove(worker);
            }
        }
    }
}
