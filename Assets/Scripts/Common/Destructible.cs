using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int maxLives = 5;
    [SerializeField] private GameObject deathEffect;
    
    [SerializeField] public int currentLives = 5;

    public void Start()
    {
        currentLives = maxLives;
    }

    public void OnHit(int damage)
    {
        currentLives -= damage;
        if (currentLives <= 0)
        {
            currentLives = 0;
            DestroySelf();
        }
    }
    
    public void DestroySelf()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
