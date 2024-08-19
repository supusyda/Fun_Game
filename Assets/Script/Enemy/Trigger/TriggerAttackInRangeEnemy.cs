using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackInRangeEnemy : TriggerAttackInRange
{
    // Start is called before the first frame update
    EnemyBase enemy;
    protected override void Awake()
    {
        base.Awake();
        enemy = GetComponentInParent<EnemyBase>();

    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Player"))
        {
            enemy.setAttackWithInRange(true);

        }
    }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.CompareTag("Player"))
        {
            enemy.setAttackWithInRange(false);
        }
    }
}
