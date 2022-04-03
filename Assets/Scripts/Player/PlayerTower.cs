using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private int numFramesBetweenSpawns = 12;
    private int _numFramesSinceLastSpawn = 0;
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private MissileMovement projectile;
    
    private Transform _myTransform;
    
    void Start()
    {
        _myTransform = transform;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_numFramesSinceLastSpawn == 0)
            {
                Spawn();
            }
            ++_numFramesSinceLastSpawn;
            if (_numFramesSinceLastSpawn >= numFramesBetweenSpawns)
            {
                _numFramesSinceLastSpawn = 0;
            }
        }
        else
        {
            _numFramesSinceLastSpawn = 0;
        }
    }

    private void Spawn()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        var myPosition = _myTransform.position;
        MissileMovement clone = Instantiate(projectile, myPosition, _myTransform.rotation);
        clone.direction = Vector3.Normalize(mousePosition - myPosition);
    }
}
