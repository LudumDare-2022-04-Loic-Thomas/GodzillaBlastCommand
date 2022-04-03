using UnityEngine;

public class ExplosionPoof : MonoBehaviour
{
    [SerializeField] private float selfDestroyTime = 0.5f;
    
    void Start()
    {
        Destroy(gameObject, selfDestroyTime);
    }
}
