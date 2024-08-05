using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    protected override void hitAnim()
    {
        // animator.SetTrigger("getHit");
        transform.parent.GetComponent<EnemyAI>().onGettingHit();

    }
}
