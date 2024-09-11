using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySO : ScriptableObject
{
  // Start is called before the first frame update
  public float cooldown;
  public float cooldownRemaining;
  public new string name;
  public Sprite sprite;
  public SkillType skillType;
  public Skill skill;
  public virtual void Init(Transform transform)
  {


  }
  public virtual void Use(Transform transform)
  {

  }
  public virtual void OnBegin()
  {

  }
  public virtual void Update()
  {

  }
  public virtual void OnEnd()
  {

  }

}
