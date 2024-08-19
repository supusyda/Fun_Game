using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetectorRangeAttack
 : TriggerAttackInRange
{
    public Shooter shooter;
    public AllyBase allyBase;
    public List<Transform> targets = new List<Transform>();
    // public Transform[] targets;
    override protected void Awake()
    {
        base.Awake();
        shooter = GetComponentInParent<Shooter>();
    }
    override protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targets.Add(other.transform);
            shooter.SetTarget(targets);
            
        }
    }
    override protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targets.Remove(other.transform);
            shooter.SetTarget(targets);
        }
    }
}
