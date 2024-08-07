using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    [SerializeField] Transform player;
    protected override void hitAnim()
    {
        // animator.SetTrigger("getHit");
        transform.parent.GetComponent<EnemyAI>().onGettingHit();
        hitParticle();

    }
    void hitParticle()
    {
        Vector3 dir = (transform.position - player.position).normalized;
        // float tan = dir.y / dir.x;
        // float t = 0;
        // if (tan < 0) t = 1;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Transform particle = ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.HIT_PARTICLE);
        
        Debug.Log(rot_z);
        particle.gameObject.SetActive(true);
        particle.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
