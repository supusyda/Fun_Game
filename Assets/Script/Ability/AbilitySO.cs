using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySO : ScriptableObject
{
  // Start is called before the first frame update
  public float cooldown;

  public new string name;
  public Sprite sprite;
  public SkillType skillType;
  public Skill skill;
  public Skill UnlockCondition;
  AbilityHolder abilityHolder;
  public virtual void Init(Transform transform)
  {
    
    abilityHolder = transform.GetComponent<AbilityHolder>();




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
  public virtual void OnUnlock()
  {
    switch (skillType)//depend on skill type has diff way to handle
    {
      case SkillType.Stat:
        {
          PlayerCtr.Stat.AddStatByAbility(this);
          break;
        }
      case SkillType.Active:
        {

          abilityHolder.AddSkillToActiveSkill(skill);                       // fire event to UI to show unlock skill on screen
          break;
        }
      case SkillType.Turret:
        {
          BuildingTypeSelect.onUnlockBuilding.Invoke(skill);
          break;
        }
      default: break;
    }
  }

}
