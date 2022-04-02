using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] public int maxLifes = 5;
    [SerializeField] public int currentLifes;
    [SerializeField] public GameObject deathEffect;

    [SerializeField] private EnemySpawner enemySpawner;

    private string myName;
    
    // Start is called before the first frame update
    void Start()
    {
        myName = gameObject.name;
        currentLifes = maxLifes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision between " + myName + " and " + collision.gameObject.name);
        EnemyMissile enemyMissile = collision.gameObject.GetComponent<EnemyMissile>();
        if (enemyMissile != null)
        {
            Debug.Log("The city collided with an enemy missile!");
            enemyMissile.DestroySelf();
            currentLifes -= enemyMissile.damage;

            if(currentLifes <= 0)
            {
                DestroySelf();
            }
        }
    }

    private void DestroySelf()
    {
        enemySpawner.CityDestroyed(this);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetEnemySpawner(EnemySpawner _spawner)
    {
        enemySpawner = _spawner;
    }

}
