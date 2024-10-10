using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SummonCrewAbility", menuName = "Skill/Summon")]
public class SummonCrewAbilitySO : AbilitySO
{
    // Start is called before the first frame update
    Transform transform;
    GameObject gameObject;
    public Transform prefab;
    public override void Use(Transform transform)
    {


    }
    public override void OnBegin()
    {

        CrewSpawner.Instance.SpawnCrewAroundPlayer();

    }
    public override void Update()
    {

    }
    public override void OnEnd()
    {

    }
}
