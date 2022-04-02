using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] public Vector3 speed;
    [SerializeField] public Vector3 acceleration = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        Vector3 deltaPos = speed * Time.deltaTime;
        float angle = Mathf.Atan2(deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;
        transform.position += deltaPos;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
