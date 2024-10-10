using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpStatAbilitySO", menuName = "Skill/UpStat")]

public class UpStatAbilitySO : AbilitySO
{
    public enum StatType
    {
        Hp, MovementSpeed, AttackSpeed
    }

    public UpStatAbilitySO(UpStatAbilitySO upStatAbilitySO)
    {

    }
    public int additinalAmout;
    public StatType statType;
  
    public Transform prefab;

}
