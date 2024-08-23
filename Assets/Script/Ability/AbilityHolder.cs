using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
public enum AbilityState
{
  ready, active, cooldown
}
public class AbilityHolder : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField] List<AbilitySO> abilitySOs = new List<AbilitySO>();
  [SerializeField] Ability currentAbility;


  List<Ability> abilitis = new List<Ability>();

  private void Awake()
  {
    Init();
  }
  void Init()
  {
    foreach (AbilitySO ability in abilitySOs)
    {
      Ability ab = new Ability(ability, AbilityState.ready,transform);
      abilitis.Add(ab);
    }
    EventDefine.onAbilityInit?.Invoke(abilitySOs);
    
  }
  private void Update() {
    if(Input.GetKeyDown(KeyCode.Space))
    {
      abilitis[0].OnBegin();


    }
    foreach (Ability ability in abilitis)
    {
      ability.UpdateCooldown();
    }
  }
}
