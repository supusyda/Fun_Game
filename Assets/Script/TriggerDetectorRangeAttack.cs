using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : TriggerAttackInRange
{
    public Shooter shooter;
    AllyBase allyBase;

    public List<Transform> targets = new List<Transform>();
    // public Transform[] targets;
    override protected void Awake()
    {
        base.Awake();
        shooter = GetComponentInParent<Shooter>();
        allyBase = GetComponentInParent<AllyBase>();
    }
    override protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Add(other.transform);
            shooter.SetTarget(targets);
            allyBase.setAttackWithInLongRange(true);
        }
    }
    override protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.transform);
            if (targets.Count > 0)
            {
                shooter.SetTarget(targets);
                return;

            };
            allyBase.setAttackWithInLongRange(false);

        }
    }
}
