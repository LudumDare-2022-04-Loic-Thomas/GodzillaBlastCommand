using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class SkyProjectileSpawner : Spawner
    {
        [SerializeField] private List<Transform> targets;
        [SerializeField] private BoxCollider2D box;

        private Vector3 _min;
        private Vector3 _max;

        public void Start()
        {
            var bounds = box.bounds;
            _min = bounds.min;
            _max = bounds.max;
        }
        
        public new void FixedUpdate()
        {
            targets.RemoveAll(city => city == null);
            if (targets.Count != 0)
                base.FixedUpdate();
        }

        protected override Vector3 GetSpawnPoint()
        {
            return new Vector3(Random.Range(_min.x, _max.x), Random.Range(_min.y, _max.y), 0);
        }

        protected override void AfterSpawn(GameObject spawnedObject)
        {
            int targetIndex = Random.Range(0, targets.Count);
            Vector3 aim = targets[targetIndex].position;
            Vector3 spawnedPos = spawnedObject.transform.position;
            spawnedObject.GetComponent<MissileMovement>().direction = (aim - spawnedPos).normalized;
        }
    }
}
