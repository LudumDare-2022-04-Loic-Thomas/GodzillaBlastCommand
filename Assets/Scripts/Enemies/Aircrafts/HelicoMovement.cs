using UnityEngine;

public class HelicoMovement : MonoBehaviour
{
    [SerializeField] private float maxDropTime = 2.0f;
    [SerializeField] private float speed = 0.5f;

    private float _droppingTime = 0;
    
    void FixedUpdate()
    {
        if (_droppingTime >= maxDropTime)
            return;

        _droppingTime += Time.deltaTime;
        transform.position += speed * Time.deltaTime * Vector3.down;
    }
}
