using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Arrow : Projectile
{
    protected override void onHitTarget(Transform target)
    {
        if (!target.CompareTag("Enemy")) return;
        base.onHitTarget(target);
    }
}
