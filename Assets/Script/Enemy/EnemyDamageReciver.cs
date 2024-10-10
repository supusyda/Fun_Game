using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    Transform player;
    EnemyBase enemy;
    [SerializeField] SpriteRenderer spriteRenderer;
    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        enemy = GetComponentInParent<EnemyBase>();

    }
    protected override void hitAnim()
    {
        // animator.SetTrigger("getHit");
        hitParticle();

    }
    public override void TakeDamage(float damage, Vector2 knockbackVecter)
    {
        enemy.enemyStateMachine.ChangeState(enemy.enemyDamageState);

        base.TakeDamage(damage, knockbackVecter);
    }
    void hitParticle()
    {
        //rotate the particle the same dir as the player to this transform
        if (player == null) return;
        Vector3 dir = (transform.position - player.position).normalized;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Transform particle = ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.HIT_PARTICLE);
        particle.gameObject.SetActive(true);
        particle.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    // do some thing when HP <= 0 
    protected override void Die()
    {
        // transform.parent.DoFa
        Collider2D collider2D = GetComponentInParent<Collider2D>();
        collider2D.enabled = false;

        ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.DEATH_PARTICLE).gameObject.SetActive(true);
        enemy.OnDie();
        this.spriteRenderer.DOFade(0, 1).onComplete += () =>
        {
            //find if there is drop 
            DropThing drop = transform.parent.GetComponentInChildren<DropThing>();
            EnemySpawner.Instance.DespawnOjb(transform.parent);
            EventDefine.OnEnemyDie.Invoke();

            if (drop) drop.Drop();//if has then do drop
        };
    }
}
