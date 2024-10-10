using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{
    // Start is called before the first frame update
    [SerializeField] Animator _animator;
    [SerializeField] Collider2D _hitBox;

    private void OnEnable()
    {
        _hitBox.enabled = true;
    }
    protected override void onHitTarget(Transform target)
    {
        if (!target.CompareTag("Player") && !target.CompareTag("Crew")) return;
        if (target.GetComponentInChildren<DamageReciver>() == null) return;
        DamageReciver damageReciver = target.GetComponentInChildren<DamageReciver>();//Get hit object DamageReciver
        transform.GetComponentInChildren<DamageDealer>().onHittingEnemy(damageReciver);
        _hitBox.enabled = false;
        StartCoroutine(PlayHitAnim());
    }

    IEnumerator PlayHitAnim()
    {
        _isReachTargetPos = true;
        _animator.Play("Hit");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        DestroyMe();
    }
}
