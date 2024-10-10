using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class stat
{
    // Start is called before the first frame update
    [SerializeField] private int maxHp;
    public int MaxHP { get => maxHp; private set { maxHp = value; } }

    [SerializeField] private int speed;
    public int Speed { get => speed; private set { speed = value; } }
    [SerializeField] private float attackSpeed;
    public float AttackSpeed { get => attackSpeed; private set { attackSpeed = value; } }
    // private DamageReciver thisObjHealth;

    public stat(int maxHp, int speed, float attackSpeed = 1)
    {
        this.maxHp = maxHp;
        this.speed = speed;
        this.attackSpeed = attackSpeed;

    }
    public void AddStatByAbility(AbilitySO upStatAbilitySO)
    {
        UpStatAbilitySO temp = (UpStatAbilitySO)upStatAbilitySO;
        switch (temp.statType)
        {

            case UpStatAbilitySO.StatType.Hp:
                this.MaxHP += temp.additinalAmout;

                PlayerCtr.myHealth.SetMaxHP(MaxHP);
                PlayerCtr.myHealth.addHP(temp.additinalAmout);
                break;
            case UpStatAbilitySO.StatType.MovementSpeed:
                this.Speed += temp.additinalAmout;
                PlayerCtr.movement.SetMoveSpeed(this.Speed);
                break;
            case UpStatAbilitySO.StatType.AttackSpeed:
                this.AttackSpeed += temp.additinalAmout;
                PlayerCtr.SetAttackSpeed(this.AttackSpeed);
                break;
            default:

                break;
        }
    }

}
