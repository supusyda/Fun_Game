using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtrler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Collider2D attackColider1;

    public void EnableAttackColider()
    {
        attackColider1.enabled = true;
    }
    public void DisableAttackColider()
    {
        attackColider1.enabled = false;

    }
}
