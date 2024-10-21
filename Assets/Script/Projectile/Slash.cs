using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Projectile
{
    // Start is called before the first frame update
    [SerializeField] Transform explosion;
    protected override void OnReachTargetPos()
    {

        Instantiate(explosion, transform.position, Quaternion.identity);
        DestroyMe();

    }
}
