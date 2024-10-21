using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BuildingAbility", menuName = "Skill/Build")]
public class BuildingAbilitySO : AbilitySO
{
    // Start is called before the first frame update
    Transform transform;

    public override void Init(Transform transform)
    {
        this.transform = transform;


    }
    public override void Use(Transform transform)
    {


    }
    public override void OnBegin()
    {

    }
    public override void Update()
    {

    }
    public override void OnEnd()
    {

    }
}

