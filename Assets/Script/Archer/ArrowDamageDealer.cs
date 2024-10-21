using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamageDealer : DamageDealer
{
    // Start is called before the first frame update
    [SerializeField] List<HitOjb> listOfCanHit = new();
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        listOfCanHit.ForEach(hitOjb =>
        {
            if (other.CompareTag(hitOjb.Tag))
            {
                base.OnTriggerEnter2D(other);
                return;

            }
        });
    }

}
[Serializable]
public class HitOjb
{
    [SerializeField] public string Tag;
    [SerializeField] public bool Hit;
}