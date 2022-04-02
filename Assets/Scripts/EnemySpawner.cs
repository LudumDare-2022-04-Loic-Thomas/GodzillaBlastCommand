using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int NUM_FRAMES_BETWEEN_SPAWNS = 4;
    [SerializeField] private float INIT_MISSILE_SPEED = 3.0f;
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private City[] cities;

    private Vector3 min;
    private Vector3 max;
    private int numFramesSinceLastSpawn = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        min = gameObject.GetComponent<BoxCollider2D>().bounds.min;
        max = gameObject.GetComponent<BoxCollider2D>().bounds.max;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        ++numFramesSinceLastSpawn;
        if (numFramesSinceLastSpawn >= NUM_FRAMES_BETWEEN_SPAWNS)
        {
            Spawn();
            numFramesSinceLastSpawn = 0;
        }
    }

    private void Spawn()
    {
        int cityNumber = UnityEngine.Random.Range(0, cities.Length);
        Vector3 spawn = new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), 0);
        Vector3 aim = cities[cityNumber] ? cities[cityNumber].gameObject.transform.position : spawn + Vector3.down;
        GameObject enemy = Instantiate(enemyPrefab, spawn, Quaternion.identity); //Quaternion.LookRotation(aim-spawn, Vector3.up));
        enemy.GetComponent<EnemyMissile>().direction = (aim - spawn).normalized * INIT_MISSILE_SPEED;
    }
}
