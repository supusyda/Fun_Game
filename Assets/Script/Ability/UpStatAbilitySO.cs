using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpStatAbilitySO", menuName = "Skill/UpStat")]

public class UpStatAbilitySO : AbilitySO
{
    public enum Stat
    {
        Hp, MovementSpeed
    }
    Stat stat;
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
