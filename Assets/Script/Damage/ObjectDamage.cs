using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectDamage : DamageReciver
{
    protected override void Die(Action<string> callback = null)
    {
        // transform.parent.DoFa
        ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.DEATH_PARTICLE).gameObject.SetActive(true);
        SpriteRenderer spriteRenderer = transform.parent.Find("Model").GetComponent<SpriteRenderer>();
        spriteRenderer.DOFade(0, 1).onComplete += () =>
        {

            Destroy(transform.parent.gameObject);
        };
    }

}
