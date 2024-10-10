using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update
    AttackCtrler attackCtrler;
    private void Awake()
    {
        attackCtrler = transform.parent.GetComponentInChildren<AttackCtrler>();
    }
    public virtual void ActiveAttackColider()
    {
        if (attackCtrler == null) return;
        attackCtrler.EnableAttackColider();

    }
    public virtual void DisableAttackColider()
    {
        attackCtrler.DisableAttackColider();

    }
}
