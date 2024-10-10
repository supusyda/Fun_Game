using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamageDealer : DamageDealer
{
    // Start is called before the first frame update
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Crew") || other.CompareTag("Player")) return;
        base.OnTriggerEnter2D(other);
    }
}
