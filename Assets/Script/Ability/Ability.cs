using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ability
{
    // Start is called before the first frame update

    public AbilitySO abilitySO;
    Sprite sprite;
    public float timeCooldown { get; private set; }
    public int skillPointNeed { get; private set; }

    private float timeCooldownRemaining { get; set; }
    public string headerName { get; private set; }
    public string content { get; private set; }

    AbilityState abilityState;
    public Ability(AbilitySO abilitySO, AbilityState abilityState, Transform transform)
    {
        this.abilitySO = abilitySO;
        this.abilitySO.Init(transform);
        timeCooldown = abilitySO.cooldown;
        headerName = abilitySO.skillName;
        content = abilitySO.content;
        this.abilityState = abilityState;
        skillPointNeed = abilitySO.skillPoint;
    }
    public void OnBegin()
    {
        if (abilityState != AbilityState.ready) return;

        this.abilitySO.OnBegin();
        this.timeCooldownRemaining = 0;

        abilityState = AbilityState.cooldown;
        EventDefine.onAbilityUse?.Invoke(abilitySO);
    }
    public void OnEnd()
    {
        this.abilitySO.OnEnd();
    }
    public void OnUpdate()
    {
        this.abilitySO.Update();
    }
    public void UpdateCooldown()
    {
        if (abilityState != AbilityState.cooldown) return;
        timeCooldownRemaining += Time.deltaTime;
        if (timeCooldownRemaining >= timeCooldown) abilityState = AbilityState.ready;
    }

}
