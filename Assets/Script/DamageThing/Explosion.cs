using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float damage;
    [SerializeField] private float force;
    [SerializeField] private float m_nExplosionRadius;
    [SerializeField] private LayerMask layerMask;


    protected void DoDamage()
    {

        Collider2D[] ojbInRange = Physics2D.OverlapCircleAll(transform.position, m_nExplosionRadius, layerMask);

        if (ojbInRange.Length <= 0) return;


        foreach (Collider2D collider in ojbInRange)
        {
            DamageReciver health = collider.GetComponentInChildren<DamageReciver>();
            //is Enemy  ? if not return
            if (!collider.CompareTag("Enemy")) continue;
            //is the object has health
            if (health == null) continue;
            //if has do damage
            Debug.Log(collider.gameObject.name);

            Vector2 knockBackVector = collider.transform.position - transform.position;
            health.TakeDamage(damage, knockBackVector.normalized * force);
        }
    }
    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
