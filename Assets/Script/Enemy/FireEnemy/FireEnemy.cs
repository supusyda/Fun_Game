using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireEnemy : EnemyBase
{
    // Start is called before the first frame update
    [SerializeField] Shooter shooter;
    [SerializeField] float _recoilForce;
    public override void HandleRangeAttackAttack()
    {
        List<Transform> targets = new List<Transform>
        {
            target
        };
        shooter.SetSingleTarget(target);
        shooter.BeginShoot();
        if (!target) return;
        Vector3 recoilDir = -(target.position - transform.position);
        RB.AddForce(recoilDir, ForceMode2D.Impulse);


    }

}
