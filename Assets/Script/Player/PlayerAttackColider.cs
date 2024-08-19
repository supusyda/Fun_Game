using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttackColider : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<DamageReciver>())
        {
            DamageReciver damageReciver = other.GetComponentInChildren<DamageReciver>();//Get hit object DamageReciver
            if (damageReciver == null) return;
            transform.parent.GetComponent<DamageDealer>().onHittingEnemy(damageReciver);

        }
    }
}
