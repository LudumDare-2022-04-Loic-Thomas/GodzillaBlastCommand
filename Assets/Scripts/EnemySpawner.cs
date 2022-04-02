using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public City[] cities;

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

    int i = 0;
    void FixedUpdate()
    {
        if (i < 4) ++i;
        else
        {
            Spawn();
            i = 0;
        }
    }

    private void Spawn()
    {
        int cityNumber = UnityEngine.Random.Range(0, cities.Length);
        Vector2 aim = cities[cityNumber].gameObject.transform.position;
        Vector2 spawn = new Vector2(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y));
        GameObject enemy = Instantiate(enemyPrefab, spawn, Quaternion.identity); //Quaternion.LookRotation(aim-spawn, Vector3.up));
        Debug.Log(spawn);
        enemy.GetComponent<Enemy>().direction = aim - spawn;
    }

    Vector3 min;
    Vector3 max;
}
