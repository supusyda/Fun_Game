using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
public enum AbilityState
{
  ready, active, cooldown
}
public enum Skill
{
  None, Slash, Summon, PlusHealth1, PlusHealth2, PlusSpeed1, PlusSpeed2, ArrowTower, TNTTower, PlusAttackSpeed1

}
public enum SkillType
{
  Active, Passive, Stat, Turret
}
public class AbilityHolder : MonoBehaviour
{
  [Header("Ref")]
  [SerializeField] List<AbilitySO> abilitySOs = new List<AbilitySO>();
  [Header("Atrubute")]

  [SerializeField] private float _skillPointToUnlock = 0;
  private List<Ability> unLockSkill = new List<Ability>();
  private List<Ability> unlockedActiveSkill = new List<Ability>();
  private static List<Ability> abilitis = new List<Ability>();
  private Level playerLevel;
  private void Awake()
  {
    Init();
  }
  void Init()
  {
    foreach (AbilitySO ability in abilitySOs)
    {
      Ability ab = new Ability(ability, AbilityState.ready, transform);
      abilitis.Add(ab);
    }

  }
  private void Start()
  {
    EventDefine.abiHolderRef.Invoke(this);
    SetUpLevelPlayer();
  }
  private void Update()
  {
    UsingSkill();
    // need improve
    foreach (Ability ability in unLockSkill)
    {
      ability.UpdateCooldown();
    }
  }
  public bool IsUnlockSkill(Ability skill)
  {
    //check is the skill unlocked

    return unLockSkill.Contains(skill);
  }
  public void UnLockSkill(Ability skill)
  {
    if (IsUnlockSkill(skill)) return;//check skill í unlock
    if (_skillPointToUnlock <= 0) return;//check skill is enough skill ponit
    if (!IsFullyMeetUnlockCondition(skill.abilitySO)) return;
    skill.abilitySO.OnUnlock();
    // switch (skill.abilitySO.skillType)//depend on skill type has diff way to handle
    // {
    //   case SkillType.Stat:
    //     {
    //       PlayerCtr.Stat.AddStatByAbility(skill.abilitySO);
    //       break;
    //     }
    //   case SkillType.Active:
    //     {
    //       unlockedActiveSkill.Add(skill);                       // fire event to UI to show unlock skill on screen
    //       break;
    //     }
    //   case SkillType.Turret:
    //     {
    //       BuildingTypeSelect.onUnlockBuilding.Invoke(skill.abilitySO.skill);
    //       break;
    //     }
    //   default: break;
    // }

    unLockSkill.Add(skill);// add skill to unlock skill list 
    EventDefine.onAbilityInit2?.Invoke(skill);
    _skillPointToUnlock--;// minus skill point
  }

  bool IsFullyMeetUnlockCondition(AbilitySO abilitySO)
  {
    if (abilitySO.UnlockCondition == Skill.None) return true;//if dont have condition
    return unLockSkill.Contains(GetSkill(abilitySO.UnlockCondition));// is the skill need to unlock has been unlock
  }
  void UsingSkill()
  {
    //need improve
    if (Input.GetKeyDown(KeyCode.Space))
    {
      unlockedActiveSkill[0].OnBegin();
    }
    else if (Input.GetKeyDown(KeyCode.E))
    {
      // if(unLockSkill[1])
      unlockedActiveSkill.ForEach(a =>
      {
        Debug.Log(a);
      });
      unlockedActiveSkill[1].OnBegin();

    }
  }
  public static Ability GetSkill(Skill skill)
  {

    foreach (Ability ability in abilitis)
    {
      if (ability.abilitySO.skill == skill)

        return ability;
    }
    Debug.Log("NO ABILITY FOUND");
    return null;
  }

  void SetUpLevelPlayer()
  {
    playerLevel = PlayerCtr.myLevel;
    playerLevel.OnLevelChange.AddListener(() =>
    {
      _skillPointToUnlock++;
    });
  }
  public void AddSkillToActiveSkill(Skill skill)
  {
    unlockedActiveSkill.Add(GetSkill(skill));
  }
}

