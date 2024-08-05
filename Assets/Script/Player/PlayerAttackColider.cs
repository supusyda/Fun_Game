using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttackColider : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.GetComponentInChildren<DamageReciver>())
        {
            Debug.Log(other.transform.GetComponentInChildren<DamageReciver>());
            DamageReciver damageReciver = other.GetComponentInChildren<DamageReciver>();
            EventDefine.onTargetInRange?.Invoke(damageReciver);
        }
    }
}
