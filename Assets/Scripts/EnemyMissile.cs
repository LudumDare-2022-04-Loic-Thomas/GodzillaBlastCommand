using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField] private float WORLD_HALF_WIDTH = 15.0f;
    [SerializeField] private float WORLD_HALF_HEIGHT = 9.0f;
    
    [SerializeField] public float speed = 0;
    [SerializeField] public Vector3 direction;
    [SerializeField] public GameObject deathEffect;
    [SerializeField] public int damage = 1;

    private Transform myTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    private void FixedUpdate()
    {
        Vector3 pos = myTransform.position;
        pos += speed * Time.deltaTime * direction;
        myTransform.position = pos;
        
        // Out-of-bounds = despawn
        if (Math.Abs(pos.x) >= WORLD_HALF_WIDTH || Math.Abs(pos.y) >= WORLD_HALF_HEIGHT)
        {
            DestroySelf();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySelf()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
