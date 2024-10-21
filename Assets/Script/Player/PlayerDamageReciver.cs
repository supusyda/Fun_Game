using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{
    // Start is called before the first frame update
    [SerializeField] SimpleFlash flash;
    protected override void hitAnim()
    {
        base.hitAnim();


    }
    public override void TakeDamage(float damage, Vector2 knockbackVecter)
    {
        base.TakeDamage(damage, knockbackVecter);
        float magnitude = .5f;
        float durration = .5f;
        // TimeManager.Instance.SlowDownTime();
        PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.GetHit);
        EventDefine.ShakeCamera?.Invoke(durration, magnitude);
        flash.Flash();
        AudioManager.Instance.PlayAudio(AudioManager.Instance._HURT_SFX);


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
    protected override void Die()
    {
        // transform.parent.DoFa
        ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.DEATH_PARTICLE).gameObject.SetActive(true);
        EventDefine.OnGameOver?.Invoke();
        transform.parent.Find("Model").GetComponent<SpriteRenderer>().DOFade(0, 1).onComplete += () =>
        {
            // transform.parent.Find("Model").GetComponent<SpriteRenderer>().DOFade(1, 0);
        };
    }
}
