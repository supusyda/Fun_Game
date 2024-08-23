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
  [SerializeField]  float a = 0;

    private void OnEnable()
    {
        EventDefine.onAbilityInit.AddListener(InitActiveSkillUI);
        EventDefine.onAbilityUse.AddListener(SetSkillInCoolDown);
    }
    private void OnDisable()
    {
        EventDefine.onAbilityInit.RemoveListener(InitActiveSkillUI);
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
    void SetSkillInCoolDown(AbilitySO abilitySO)
    {
        StartCoroutine(BeginCountUI(abilitySO));
    }

    IEnumerator BeginCountUI(AbilitySO abilitySO)
    {
        abilityStateDic[abilitySO].Find("Cooldown").GetComponent<Image>().fillAmount = 1;

        float fillAmount = abilitySO.cooldown;
        yield return null;
        while (fillAmount > 0)
        {

            
            fillAmount -= Time.deltaTime;
            a = fillAmount;
            // Debug.Log(a);
            float percent = fillAmount / abilitySO.cooldown;
            abilityStateDic[abilitySO].Find("Cooldown").GetComponent<Image>().fillAmount = percent;
            yield return null;
        }


    }
}
