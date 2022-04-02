using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public uint lifes = 5;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collision2D collision)
    {
        Debug.Log("hey");
        Enemy enemy = collision.gameObject.GetComponent<Enemy>() as Enemy;
        if (enemy != null)
        {
            enemy.AskDestroy();
        }

        lifes -= enemy.damages;

        if(lifes < 0)
        {
            AskDestroy();
            // Also remove city from potential cities to aim from spawner
        }
    }


    public void AskDestroy()
    {
        Instantiate(deathEffect, transform);
        Destroy(this);
    }
}
