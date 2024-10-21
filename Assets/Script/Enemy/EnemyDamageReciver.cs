using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    protected Transform player;
    EnemyBase enemy;
    SimpleFlash simpleFlash;

    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        enemy = GetComponentInParent<EnemyBase>();
        simpleFlash = transform.parent.GetComponentInChildren<SimpleFlash>();

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
        simpleFlash?.Flash();
        collider2D = GetComponentInParent<Collider2D>();
        // EventDefine.onTakeDamage.Invoke();
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

        ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.DEATH_PARTICLE).gameObject.SetActive(true);
        enemy.OnDie();
        this.spriteRenderer.DOFade(0, 1).onComplete += () =>
        {
            //find if there is drop 
            transform.parent.Find("Model").GetComponent<SpriteRenderer>().DOFade(1, 0);
            DropThing drop = transform.parent.GetComponentInChildren<DropThing>();
            if (drop) drop.Drop();//if has drop then do drop
            EnemySpawner.Instance.DespawnOjb(transform.parent);
            EventDefine.OnEnemyDie.Invoke();

        };
    }
}
