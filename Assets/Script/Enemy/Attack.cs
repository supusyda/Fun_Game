using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float attackCoolDownTimer = 0;//count to zero
    [SerializeField] float maxAttackCoolDown = 1;
    protected virtual void BeginAttack()
    {

    }
    protected virtual void EndAttack(){

    }
     protected virtual void DetectTarget(){

    }
     protected virtual void Update()
    {
        if (attackCoolDownTimer >= maxAttackCoolDown) return;
        attackCoolDownTimer += Time.deltaTime;
    }
}
