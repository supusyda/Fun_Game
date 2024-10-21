using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{

    public float damage = 1;
    public float knockBackForce = 1;
    protected DamageReciver targetHit;
    public Collider2D hitBox;
    private void Awake()
    {
        // hitBox = transform.parent.parent.GetComponent<Collider2D>();
    }

    // Start is called before the first frame update

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

        onHittingEnemy(other.GetComponentInChildren<DamageReciver>());
    }
    public virtual void onHittingEnemy(DamageReciver enemy)
    {

        if (enemy)
        {
            // CharacterEvent.dealDamage
            targetHit = enemy;

            // knockBackForce = 10f;
            Vector2 knockBackDir = (enemy.transform.position - transform.position).normalized;
            knockBackDir = knockBackDir * knockBackForce;
            targetHit.TakeDamage(damage, knockBackDir);

        }
    }

}
