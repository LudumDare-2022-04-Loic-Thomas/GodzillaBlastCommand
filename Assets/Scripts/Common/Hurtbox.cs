using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] public Destructible destruct;
    [SerializeField] public Team team = Team.Player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Hitbox hitbox = collision.gameObject.GetComponent<Hitbox>();
        if (hitbox != null && hitbox.team != team)
        {
            hitbox.OnEnemyHit();
            destruct.OnHit(hitbox.damage);
        }
    }
}
