using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] public int lives = 5;
    [SerializeField] public GameObject deathEffect;

    private string myName;
    
    // Start is called before the first frame update
    void Start()
    {
        myName = gameObject.name;
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
            lives -= enemyMissile.damage;

            if(lives <= 0)
            {
                DestroySelf();
            }
        }
    }

    private void DestroySelf()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        // Also remove city from potential cities to aim from spawner
    }
}
