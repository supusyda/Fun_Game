using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    // Start is called before the first frame update
   public float damage = 1;
    public float knockBackForce = 1000f;
    private DamageReciver targetHit;
      public void onHittingTarget(DamageReciver target)
    {

        if (target)
        {
            // CharacterEvent.dealDamage
            targetHit = target;
            knockBackForce = 20f;
            Vector2 knockBackDir = (target.transform.position - transform.position).normalized;
            knockBackDir = knockBackDir * knockBackForce;
                      targetHit.TakeDamage(damage, knockBackDir);

        }
    }

}
