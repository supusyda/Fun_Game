using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : Projectile
{
    // Start is called before the first frame update
    // override
    [SerializeField] Transform explosion;
    protected override void onHitTarget(Transform target)
    {
        if (!target.CompareTag("Enemy")) return;
        Instantiate(explosion, transform.position, Quaternion.identity);
        DestroyMe();
    }
    protected override void OnReachTargetPos()
    {
        // if (!target.CompareTag("Enemy")) return;
        Instantiate(explosion, transform.position, Quaternion.identity);
        DestroyMe();
    }

}
