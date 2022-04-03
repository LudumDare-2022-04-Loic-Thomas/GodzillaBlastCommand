using UnityEngine;

namespace Common
{
    public class MissileOrientation : MonoBehaviour
    {
        [SerializeField] private MissileMovement movement;

        public void Start()
        {
            var direction = movement.direction;
            // Missile orientation
            if (direction != Vector3.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}