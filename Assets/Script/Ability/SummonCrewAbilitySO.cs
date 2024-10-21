using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SummonCrewAbility", menuName = "Skill/Summon")]
public class SummonCrewAbilitySO : AbilitySO
{
    // Start is called before the first frame update
    public Transform prefab;
    public int crewSumAmount = 1;
    public override void Use(Transform transform)
    {


    }
    public override void OnBegin()
    {
        for (int i = 0; i < crewSumAmount; i++)
        {

            CrewSpawner.Instance.SpawnCrewAroundPlayer();
        }

    }
    public override void Update()
    {

    }
    public override void OnEnd()
    {

    }
}
