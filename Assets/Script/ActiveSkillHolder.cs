using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSkillHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform perfab;
    [SerializeField] Dictionary<AbilitySO, Transform> abilityStateDic = new Dictionary<AbilitySO, Transform>();
    [SerializeField] float a = 0;

    private void OnEnable()
    {
        // EventDefine.onAbilityInit.AddListener(InitActiveSkillUI);
        EventDefine.onAbilityInit2.AddListener(InitUnlockActiveSkillUI);

        EventDefine.onAbilityUse.AddListener(SetSkillInCoolDown);

    }
    private void OnDisable()
    {
        EventDefine.onAbilityInit.RemoveListener(InitActiveSkillUI);
        EventDefine.onAbilityInit2.RemoveListener(InitUnlockActiveSkillUI);

    }
    void InitActiveSkillUI(List<AbilitySO> abilitySOs)
    {
        foreach (AbilitySO abilitySO in abilitySOs)
        {
            Transform abBtn = Instantiate(perfab, transform);
            abBtn.Find("Skill").GetComponent<Image>().sprite = abilitySO.sprite;
            abBtn.Find("Cooldown").GetComponent<Image>().fillAmount = 0;
            abilityStateDic.Add(abilitySO, abBtn);
        }
    }
    void InitUnlockActiveSkillUI(Ability newSkillUnlock)
    {

        // abilityStateDic.Clear();//reset the dic need more improve
        //
        // foreach (Ability skill in unlockSkill)
        {
            Transform abBtn = Instantiate(perfab, transform);
            abBtn.Find("Skill").GetComponent<Image>().sprite = newSkillUnlock.abilitySO.sprite;
            abBtn.Find("Cooldown").GetComponent<Image>().fillAmount = 0;
            abilityStateDic.Add(newSkillUnlock.abilitySO, abBtn);
            // }
        }
    }
    void SetSkillInCoolDown(AbilitySO abilitySO)
    {
        StartCoroutine(BeginCountUI(abilitySO));
    }

    IEnumerator BeginCountUI(AbilitySO abilitySO)
    {
        //get the gameOjb from dic with abilitySO is the key 
        abilityStateDic[abilitySO].Find("Cooldown").GetComponent<Image>().fillAmount = 1;

        float fillAmount = abilitySO.cooldown;
        yield return null;
        while (fillAmount > 0)
        {


            fillAmount -= Time.deltaTime;
            a = fillAmount;
            float percent = fillAmount / abilitySO.cooldown;
            abilityStateDic[abilitySO].Find("Cooldown").GetComponent<Image>().fillAmount = percent;
            yield return null;
        }


    }
}
