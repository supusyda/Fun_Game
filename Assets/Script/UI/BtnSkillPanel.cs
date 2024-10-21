using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BtnSkillPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Ref")]
    [SerializeField] private AbilityHolder playerAbHolder;

    private SkillTooltipTrigger tooltip;


    [Header("Body")]

    Button_UI button;
    [SerializeField] Skill Skill;



    private void Awake()
    {
        button = GetComponent<Button_UI>();
        tooltip = GetComponent<SkillTooltipTrigger>();
    }
    private void Start()
    {
        button.ClickFunc = () =>
       {   //unlock skill depend on field skill in inspector
           if (Skill == Skill.None) return;
           playerAbHolder.UnLockSkill(AbilityHolder.GetSkill(Skill));
           if (playerAbHolder.IsUnlockSkill(AbilityHolder.GetSkill(Skill)) == true)
           {
               transform.Find("Cooldown").gameObject.SetActive(false);
               transform.Find("SkillActive").GetComponent<SkillUnlockAnimation>()?.Play();

               tooltip?.OnUnlockSkill();
           };
       };
        this.InitBtn();
    }
    void InitBtn()
    {
        Ability thisAbi = AbilityHolder.GetSkill(Skill);
        transform.Find("Skill").GetComponent<Image>().sprite = thisAbi.abilitySO.sprite;
        tooltip?.SetSkillToolTriggerText(thisAbi);
    }
    //get playerABHolder via event
}
