using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{

    public float damage = 1;
    public float knockBackForce ;
    private DamageReciver targetHit;
    public Collider2D hitBox;
    private void Awake() {
        hitBox = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
   
   private void OnTriggerExit2D(Collider2D other) {
    onHittingEnemy(other.GetComponentInChildren<DamageReciver>());
   }
    public void onHittingEnemy(DamageReciver enemy)
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
