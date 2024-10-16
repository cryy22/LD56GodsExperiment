using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GodsExperiment
{
    public class NumberParticlePool : MonoBehaviour
    {
        private const float _duration = 0.5f;
        private const float _travelDistance = 33f;

        [SerializeField] private TMP_Text NumberParticlePrefab;
        private readonly List<TMP_Text> _inactiveParticles = new(128);
        private readonly HashSet<Schedule> _schedules = new(128);
        private readonly HashSet<Schedule> _toUnschedule = new(128);

        private int _scheduleId;

        private void Update()
        {
            foreach (Schedule schedule in _schedules)
            {
                if (schedule.EndTime < Time.time)
                    _toUnschedule.Add(schedule);

                float progress = (Time.time - schedule.StartTime) / _duration;
                schedule.Particle.transform.localPosition = Vector3.Lerp(
                    a: schedule.StartPos,
                    b: schedule.EndPos,
                    t: progress
                );
                schedule.Particle.alpha = 1 - progress;
            }

            foreach (Schedule schedule in _toUnschedule)
            {
                schedule.Particle.gameObject.SetActive(false);
                _inactiveParticles.Add(schedule.Particle);
                _schedules.Remove(schedule);
            }

            _toUnschedule.Clear();
        }

        public void PlayParticle(float number, Vector3 startPos /* world position */)
        {
            startPos = transform.InverseTransformPoint(startPos);
            TMP_Text particle = GetParticle();
            particle.text = $"{number:F1}";
            particle.color = number > 0 ? Constants.Green : Constants.Red;

            _schedules.Add(
                new Schedule
                {
                    Id = _scheduleId,
                    Particle = particle,
                    StartPos = startPos,
                    EndPos = startPos +
                             Quaternion.Euler(x: 0, y: 0, z: Random.Range(minInclusive: -45, maxExclusive: 45)) *
                             (number > 0 ? Vector3.up : Vector3.down)
                             * _travelDistance,
                    StartTime = Time.time,
                }
            );
            _scheduleId++;
        }

        public TMP_Text GetParticle()
        {
            if (_inactiveParticles.Count > 0)
            {
                int lastIndex = _inactiveParticles.Count - 1;
                TMP_Text particle = _inactiveParticles[lastIndex];
                _inactiveParticles.RemoveAt(lastIndex);

                particle.gameObject.SetActive(true);
                return particle;
            }

            return Instantiate(original: NumberParticlePrefab, parent: transform);
        }

        private struct Schedule : IEquatable<Schedule>
        {
            public int Id;
            public TMP_Text Particle;
            public Vector3 StartPos;
            public Vector3 EndPos;
            public float StartTime;

            public float EndTime => StartTime + _duration;

            #region IEquatable

            public bool Equals(Schedule other) { return Id == other.Id; }
            public override bool Equals(object obj) { return obj is Schedule other && Equals(other); }
            public override int GetHashCode() { return Id; }
            public static bool operator ==(Schedule left, Schedule right) { return left.Equals(right); }
            public static bool operator !=(Schedule left, Schedule right) { return !left.Equals(right); }

            #endregion
        }
    }
}
