using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private float INIT_MISSILE_SPEED = 3.0f;
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerMissile projectile;
    
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
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;
            var myPosition = myTransform.position;
            PlayerMissile clone = Instantiate(projectile, myPosition, myTransform.rotation);
            clone.speed = Vector3.Normalize(mousePosition - myPosition) * INIT_MISSILE_SPEED;
        }
    }
}
