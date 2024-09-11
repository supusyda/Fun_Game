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
  Slash, Summon, PlusHealth1, PlusHealth2, PlusSpeed1, PlusSpeed2

}
public enum SkillType
{
  Active, Passive, Stat
}
public class AbilityHolder : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField] List<AbilitySO> abilitySOs = new List<AbilitySO>();
  // [SerializeField] private int[] keyCodeSkill = { 113, 101 };
  [SerializeField] Ability currentAbility;
  public static List<Ability> abilitis = new List<Ability>();
  List<Ability> unLockSkill = new List<Ability>();
  [SerializeField] private float _skillPointToUnlock = 0;
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
    foreach (Ability ability in unLockSkill)
    {
      ability.UpdateCooldown();
    }
  }
  //check is the skill unlocked
  public bool IsUnlockSkill(Ability skill)
  {
    return unLockSkill.Contains(skill);
  }
  public void UnLockSkill(Ability skill)
  {
    if (IsUnlockSkill(skill)) return;
    if (_skillPointToUnlock <= 0) return;
    unLockSkill.Add(skill);
    EventDefine.onAbilityInit2?.Invoke(skill);
    _skillPointToUnlock--;
  }

  void UsingSkill()
  {
    //need improve
    if (Input.GetKeyDown(KeyCode.Space))
    {
      unLockSkill[0].OnBegin();
    }
    else if (Input.GetKeyDown(KeyCode.E))
    {
      // if(unLockSkill[1])
      unLockSkill[1].OnBegin();

    }
  }
  public static Ability GetSkill(Skill skill)
  {
    Ability tempAb = null;
    foreach (Ability ability in abilitis)
    {
      if (ability.abilitySO.skill == skill)
      {
        tempAb = ability;
        return tempAb;
      }
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
}

