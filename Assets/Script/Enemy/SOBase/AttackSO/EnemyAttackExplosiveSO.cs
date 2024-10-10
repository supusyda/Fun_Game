using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy-Attack-Explosive", menuName = "Enemy/Attack/Kaboom")]
public class EnemyAttackExplosiveSO : EnemyAttackSOBase
{
    // Start is called before the first frame update
    private string m_animationName = "Explosive";
    [SerializeField] private float m_nExplosionRadius;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float damage;
    [SerializeField] private float froce;


    override public async void DoEnterState()
    {
        base.DoEnterState();
        enemy.animator.Play(m_animationName);
    }
    override public void DoFrameUpdate()
    {
        base.DoFrameUpdate();
        if (CheckAnimationStateIsPlaying()) return;
        enemy.enemyStateMachine.ChangeState(enemy.enemyRoamingState);
    }
    public bool CheckAnimationStateIsPlaying()
    {

        if (enemy.animator.GetCurrentAnimatorStateInfo(0).IsName(m_animationName) && enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            return true;
        return false;
    }
    public override void DoAnimationTriggerEvent(EnemyBase.AnimationTriggerEvent triggerEvent)
    {
        base.DoAnimationTriggerEvent(triggerEvent);
        switch (triggerEvent)
        {
            case EnemyBase.AnimationTriggerEvent.BeginExplosive:

                Collider2D[] ojbInRange = Physics2D.OverlapCircleAll(transform.position, m_nExplosionRadius, layerMask);

                if (ojbInRange.Length <= 0) return;


                foreach (Collider2D collider in ojbInRange)
                {
                    
                    DamageReciver health = collider.GetComponentInChildren<DamageReciver>();
                    //is player and crew ? if not return
                    if (!collider.CompareTag("Player") && !collider.CompareTag("Crew")) continue;
                    //is the object has health
                    if (health == null) continue;
                    //if has do damage
                    Vector2 knockBackVector = collider.transform.position - transform.position;
                    health.TakeDamage(damage, knockBackVector.normalized * froce);
                }
                break;

        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_nExplosionRadius);
    }
}
