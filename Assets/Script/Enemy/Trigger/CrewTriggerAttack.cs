using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewTriggerAttack : TriggerAttackInRange
{
    // Start is called before the first frame update
    Crew crew;
    
    protected override void Awake()
    {
        base.Awake();
        crew = GetComponentInParent<Crew>();

    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Enemy"))
        {
          
            crew.setAttackWithInRange(true);

        }
    }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.CompareTag("Enemy"))
        {
            crew.setAttackWithInRange(false);
        }
    }

}
