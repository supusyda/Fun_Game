using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{

    public float damage = 1;
    public float knockBackForce = 0.01f;
    private DamageReciver targetHit;


    // Start is called before the first frame update
    void Start()
    {
        EventDefine.onTargetInRange.AddListener(onHittingEnemy);
    }

    void OnDestroy()
    {
        EventDefine.onTargetInRange.RemoveListener(onHittingEnemy);
    }
    public void onHittingEnemy(DamageReciver enemy)
    {

        if (enemy)
        {
            // CharacterEvent.dealDamage
            targetHit = enemy;


            Vector2 knockBackDir = (enemy.gameObject.transform.position - transform.position).normalized;
            knockBackDir = knockBackDir * this.knockBackForce;

            targetHit.TakeDamage(damage, knockBackDir);

        }
    }

}
