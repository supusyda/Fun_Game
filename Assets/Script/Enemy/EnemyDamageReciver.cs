using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    [SerializeField] Transform player;
    [SerializeField] SpriteRenderer spriteRenderer;
    protected override void hitAnim()
    {
        // animator.SetTrigger("getHit");
        transform.parent.GetComponent<EnemyAI>().onGettingHit();
        hitParticle();

    }
    void hitParticle()
    {
        //rotate the particle the same dir as the player to this transform
        Vector3 dir = (transform.position - player.position).normalized;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Transform particle = ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.HIT_PARTICLE);
        particle.gameObject.SetActive(true);
        particle.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    protected override void Die(Action<string> callback = null)
    {
        // transform.parent.DoFa
        ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.DEATH_PARTICLE).gameObject.SetActive(true);

        this.spriteRenderer.DOFade(0, 1).onComplete += () =>
        {
            transform.parent.GetComponent<EnemyAI>().SetStateToDie();
            Destroy(transform.parent.gameObject);
        };
    }
}
