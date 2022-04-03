using UnityEngine;

public class BomberMovement : MonoBehaviour
{
    [SerializeField] private float worldHalfWidth = 8.5f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private bool isGoingRight = true;
    [SerializeField] private SpriteRenderer sprite;

    private Transform _myTransform;

    private void Start()
    {
        _myTransform = transform;
    }

    void FixedUpdate()
    {
        _myTransform.position += speed * Time.deltaTime * (isGoingRight ? Vector3.right : Vector3.left);
        if (_myTransform.position.x >= worldHalfWidth)
        {
            isGoingRight = false;
            sprite.flipX = false;
        }
        else if (_myTransform.position.x <= -worldHalfWidth)
        {
            isGoingRight = true;
            sprite.flipX = true;
        }
    }
}
