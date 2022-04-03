using UnityEngine;

namespace Spawners
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private int numFramesBetweenSpawns = 300;
        [SerializeField] private GameObject objectToSpawn;
        private int _numFramesSinceLastSpawn = 0;
        
        public void FixedUpdate()
        {
            ++_numFramesSinceLastSpawn;
            if (_numFramesSinceLastSpawn >= numFramesBetweenSpawns)
            {
                Spawn();
                _numFramesSinceLastSpawn = 0;
            }
        }

        private void Spawn()
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, GetSpawnPoint(), Quaternion.identity);
            AfterSpawn(spawnedObject);
        }
        
        protected virtual Vector3 GetSpawnPoint()
        {
            return transform.position;
        }
        
        protected virtual void AfterSpawn(GameObject spawnedObject) {}
    }
}