using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTooltipTrigger : TooltipTrigger
{
    public string skillPontText;
    public string cooldownText;
    public Sprite sprite;
    private bool _isSkillUnlock = false;
    private Skill unlockCondition;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // delay = LeanTween.delayedCall(0.3f, () =>
        //  {
        //      TooltipSystem.Show(content, header);

        //  });
        TooltipSystem.ShowSkillToolTip(content, header, skillPontText, cooldownText, sprite, _isSkillUnlock);
    }
    public void SetSkillToolTriggerText(Ability thisAbility)
    {

        unlockCondition = thisAbility.abilitySO.UnlockCondition;
        this.content = thisAbility.content;
        this.header = thisAbility.headerName;
        this.skillPontText = "Needed Skill Point: " + thisAbility.skillPointNeed.ToString() + " , " + (unlockCondition.ToString() == "None" ? "" : unlockCondition.ToString());
        this.cooldownText = thisAbility.timeCooldown != 0 ? "Cooldown: " + thisAbility.timeCooldown.ToString() : "";
        this.sprite = thisAbility.abilitySO.sprite;

    }
    public void OnUnlockSkill()
    {
        _isSkillUnlock = true;
        // this.skillPontText
        this.skillPontText = "THIS SKILL HAS BEEN UNLOCKED";
    }
    // Start is called before the first frame update

}
