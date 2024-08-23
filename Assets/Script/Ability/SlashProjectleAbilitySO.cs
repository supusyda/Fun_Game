using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SlashProjectleAbility", menuName = "Skill/Slash")]
public class SlashProjectleAbilitySO : AbilitySO
{
    // Start is called before the first frame update
    Transform transform;
    GameObject gameObject;
       public Transform prefab;
    public override void Init(Transform transform)
    {
        this.transform = transform;
        

    }
    public override void Use(Transform transform)
    {
        transform.GetComponentInParent<Shooter>().BeginShoot();

    }
    public override void OnBegin()
    {
        
        transform.GetComponentInParent<Shooter>().BeginShoot();
    }
    public override void Update()
    {

    }
    public override void OnEnd()
    {

    }
}
