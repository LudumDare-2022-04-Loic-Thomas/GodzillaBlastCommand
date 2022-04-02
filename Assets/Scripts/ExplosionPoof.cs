using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPoof : MonoBehaviour
{
    [SerializeField] private float SELF_DESTROY_TIME = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, SELF_DESTROY_TIME);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
