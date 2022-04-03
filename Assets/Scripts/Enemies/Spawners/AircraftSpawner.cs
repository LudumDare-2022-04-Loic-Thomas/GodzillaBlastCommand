using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class AircraftSpawner : Spawner
    {
        [SerializeField] private BoxCollider2D box;
        [SerializeField] private List<Transform> aircraftTargets;

        private Vector3 _min;
        private Vector3 _max;

        public void Start()
        {
            var bounds = box.bounds;
            _min = bounds.min;
            _max = bounds.max;
        }

        protected override Vector3 GetSpawnPoint()
        {
            return new Vector3(Random.Range(_min.x, _max.x), Random.Range(_min.y, _max.y), 0);
        }

        protected override void AfterSpawn(GameObject spawnedObject)
        {
            var comp = spawnedObject.GetComponent<AircraftProjectileSpawner>();
            if (comp != null)
            {
                comp.targets = new List<Transform>(aircraftTargets);
            }
        }
    }
}