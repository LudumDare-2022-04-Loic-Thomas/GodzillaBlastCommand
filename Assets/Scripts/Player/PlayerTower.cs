using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private float initMissileSpeed = 3.0f;
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private MissileMovement projectile;
    
    private Transform _myTransform;
    
    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;
            var myPosition = _myTransform.position;
            MissileMovement clone = Instantiate(projectile, myPosition, _myTransform.rotation);
            clone.direction = Vector3.Normalize(mousePosition - myPosition);
        }
    }
}
