using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] public Destructible destruct;
    [SerializeField] public Team team = Team.Player;
    [SerializeField] public bool destroyOnHit = true;
    [SerializeField] public int damage = 1;

    public void OnEnemyHit()
    {
        if (destroyOnHit)
        {
            destruct.DestroySelf();
        }
    }
}
