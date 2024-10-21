using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : DamageDealer
{
    // Start is called before the first frame update
    //    public float damage = 1;
    //     public float knockBackForce = 1000f;

    protected override void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy")) return;
        base.OnTriggerEnter2D(other);
    }
    public void onHittingTarget(DamageReciver target)
    {

        if (target)
        {
            // CharacterEvent.dealDamage
            targetHit = target;
            // knockBackForce = 20f;
            Vector2 knockBackDir = (target.transform.position - transform.position).normalized;
            knockBackDir = knockBackDir * knockBackForce;
            targetHit.TakeDamage(damage, knockBackDir);

        }
    }

}
