using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{
    // Start is called before the first frame update
    protected override void hitAnim()
    {
        base.hitAnim();


    }
    public override void TakeDamage(float damage, Vector2 knockbackVecter)
    {
        base.TakeDamage(damage, knockbackVecter);
        PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.GetHit);
    }
    protected override void hitParticle(Vector2 particleDir)
    {
        //rotate the particle the same dir as the player to this transform
        Vector3 dir = particleDir.normalized;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Transform particle = ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.HIT_PARTICLE);
        particle.gameObject.SetActive(true);
        particle.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    protected override void Die(Action<string> callback = null)
    {
        // transform.parent.DoFa
        ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.DEATH_PARTICLE).gameObject.SetActive(true);

        transform.parent.Find("Model").GetComponent<SpriteRenderer>().DOFade(0, 1).onComplete += () =>
        {

            Destroy(transform.parent.gameObject);
        };
    }
}
