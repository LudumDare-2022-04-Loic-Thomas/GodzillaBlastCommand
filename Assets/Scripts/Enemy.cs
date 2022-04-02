using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 0;
    public Vector3 direction;
    public GameObject deathEffect;
    public uint damages;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position += speed * Time.deltaTime * direction ;
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AskDestroy()
    {
        Instantiate(deathEffect, transform);
        Destroy(this);
    }

}
