using System;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    [SerializeField] private float WORLD_HALF_WIDTH = 12.0f;
    [SerializeField] private float WORLD_HALF_HEIGHT = 7.0f;

    [SerializeField] private GameObject deathEffect;
    
    [SerializeField] public Vector3 speed;
    [SerializeField] public Vector3 acceleration = Vector3.zero;

    private string myName;
    
    // Start is called before the first frame update
    void Start()
    {
        myName = gameObject.name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        
        // Movement equations
        speed += acceleration * Time.deltaTime;
        Vector3 deltaPos = speed * Time.deltaTime;

        // Missile orientation
        if (deltaPos != Vector3.zero)
        {
            float angle = Mathf.Atan2(deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        // Missile movement
        pos += deltaPos;
        transform.position = pos;
        
        // Out-of-bounds = despawn
        if (Math.Abs(pos.x) >= WORLD_HALF_WIDTH || Math.Abs(pos.y) >= WORLD_HALF_HEIGHT)
        {
            Destroy(gameObject);
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision between " + myName + " and " + collision.gameObject.name);
        EnemyMissile enemyMissile = collision.gameObject.GetComponent<EnemyMissile>();
        if (enemyMissile != null)
        {
            Debug.Log("The player missile collided with an enemy missile!");
            enemyMissile.DestroySelf();
            DestroySelf();
        }
    }
    
    private void DestroySelf()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}