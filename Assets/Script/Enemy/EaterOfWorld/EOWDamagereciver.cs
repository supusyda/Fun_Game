using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EOWDamagereciver : EnemyDamageReciver
{
    // Start is called before the first frame update
    protected override void Die()
    {
        // transform.parent.DoFa
        Collider2D collider2D = GetComponentInParent<Collider2D>();
        collider2D.enabled = false;

        ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.DEATH_PARTICLE).gameObject.SetActive(true);

        spriteRenderer.DOFade(0, 1).onComplete += () =>
        {
            //find if there is drop 
            transform.parent.Find("Model").GetComponent<SpriteRenderer>().DOFade(1, 0);
            DropThing drop = transform.parent.GetComponentInChildren<DropThing>();
            if (drop) drop.Drop();//if has then do drop
            EnemySpawner.Instance.DespawnOjb(transform.parent.parent);
            EventDefine.OnEnemyDie.Invoke();

        };
    }
}
