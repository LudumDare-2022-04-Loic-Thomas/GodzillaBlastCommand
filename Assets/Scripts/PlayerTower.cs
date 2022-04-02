using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private float INIT_MISSILE_SPEED = 3.0f;
    
    [SerializeField] private Camera MainCamera;
    [SerializeField] public Missile projectile;
    
    private Transform myTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = MainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;
            var myPosition = myTransform.position;
            Missile clone = Instantiate(projectile, myPosition, myTransform.rotation);
            clone.speed = Vector3.Normalize(mousePosition - myPosition) * INIT_MISSILE_SPEED;
        }
    }
}
