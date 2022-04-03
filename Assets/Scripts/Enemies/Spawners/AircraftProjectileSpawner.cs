using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public class AircraftProjectileSpawner : Spawner
    {
        [SerializeField] public List<Transform> targets;
    
        public new void FixedUpdate()
        {
            targets.RemoveAll(city => city == null);
            if (targets.Count != 0)
                base.FixedUpdate();
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