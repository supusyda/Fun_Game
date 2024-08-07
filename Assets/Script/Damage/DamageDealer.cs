using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{

    public float damage = 1;
    public float knockBackForce = 1000f;
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
            knockBackForce = 1f;
            Vector2 knockBackDir = (enemy.transform.position - transform.position).normalized;
            knockBackDir = knockBackDir * knockBackForce;
                      targetHit.TakeDamage(damage, knockBackDir);

        }
    }

}
