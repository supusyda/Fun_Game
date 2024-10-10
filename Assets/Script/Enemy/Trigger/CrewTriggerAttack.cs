using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewTriggerAttack : TriggerAttackInRange
{
    // Start is called before the first frame update
    Crew crew;
    public List<Transform> targets = new();

    protected override void Awake()
    {
        base.Awake();
        crew = GetComponentInParent<Crew>();

    }
    private void OnDisable()
    {
        targets.Clear();
        crew.setAttackWithInRange(false);
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Enemy"))
        {

            crew.setAttackWithInRange(true);
            // targets.Add(other.transform);

        }
    }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        // check enemy is out of range
        if (other.CompareTag("Enemy"))
        {
            //then remove out of target list
            targets.Remove(other.transform);

            if (targets.Count > 0) return;//no target found stop attack
            crew.setAttackWithInRange(false);


            // crew.target = null;
        }
    }

}
