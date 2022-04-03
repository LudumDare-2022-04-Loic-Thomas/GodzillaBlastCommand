using System;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] private float worldHalfWidth = 15.0f;
    [SerializeField] private float worldHalfHeight = 9.0f;
    
    [SerializeField] public float speed = 0;
    [SerializeField] public Vector3 direction;

    private Transform _myTransform;
    
    void Start()
    {
        _myTransform = transform;
    }

    private void FixedUpdate()
    {
        // Movement equation
        _myTransform.position += speed * Time.deltaTime * direction;
        
        // Out-of-bounds = despawn
        if (Math.Abs(_myTransform.position.x) >= worldHalfWidth || Math.Abs(_myTransform.position.y) >= worldHalfHeight)
        {
            Destroy(gameObject);
        }
    }
}
