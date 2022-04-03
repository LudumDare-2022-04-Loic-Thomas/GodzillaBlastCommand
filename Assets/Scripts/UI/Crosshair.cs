using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }
    
    public void SetVisible(bool visible)
    {
        Cursor.visible = !visible;
        gameObject.GetComponent<SpriteRenderer>().enabled = visible;
    }
}