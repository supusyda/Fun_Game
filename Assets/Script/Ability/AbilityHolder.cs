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
  None, BigFireBall, Summon, PlusHealth1, PlusHealth2, PlusSpeed1, PlusSpeed2, ArrowTower, TNTTower, PlusAttackSpeed1, SlashEffect1, PlusMaxTurret1, PlusMaxTurret2

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
  void OnDisable()
  {
    playerLevel?.OnLevelChange?.RemoveListener(OnLevelChange);
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
    if (IsNotHaveEnoughSkillPoint(skill.skillPointNeed)) return;//check skill is enough skill ponit
    if (!IsFullyMeetUnlockCondition(skill.abilitySO)) return;
    skill.abilitySO.OnUnlock();
    unLockSkill.Add(skill);// add skill to unlock skill list 
    EventDefine.onAbilityInit2?.Invoke(skill);
    OnUsingSkillPoint(skill.skillPointNeed);// minus skill point
  }

  bool IsFullyMeetUnlockCondition(AbilitySO abilitySO)
  {
    if (abilitySO.UnlockCondition == Skill.None) return true;//if dont have condition
    return unLockSkill.Contains(GetSkill(abilitySO.UnlockCondition));// is the skill need to unlock has been unlock
  }
  bool IsNotHaveEnoughSkillPoint(int skillPoint)
  {
    return _skillPointToUnlock <= 0 || _skillPointToUnlock < skillPoint;
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
    playerLevel.OnLevelChange.AddListener(OnLevelChange);
  }
  void OnLevelChange()
  {
    _skillPointToUnlock++;
    SkillPointUIText.onSkillPointChange.Invoke((int)_skillPointToUnlock);
  }
  void OnUsingSkillPoint(int amount)
  {
    _skillPointToUnlock -= amount;
    SkillPointUIText.onSkillPointChange.Invoke((int)_skillPointToUnlock);
  }
  public float GetSkillPointToUnlock()
  {
    return _skillPointToUnlock;
  }
  public void AddSkillToActiveSkill(Skill skill)
  {
    unlockedActiveSkill.Add(GetSkill(skill));
  }
}

