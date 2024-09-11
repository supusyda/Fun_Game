using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BtnSkillPanel : MonoBehaviour
{
    // Start is called before the first frame update

    Button_UI button;
    [SerializeField] Skill Skill;
    [SerializeField] private AbilityHolder playerAbHolder;
    private void OnEnable()
    {

    }
    private void Awake()
    {
        // EventDefine.abiHolderRef.AddListener((playerAbHolder) =>
        // {
        //     SetPlayerAbHolder(playerAbHolder);
        // });

        button = GetComponent<Button_UI>();

    }
    private void Start()
    {
        button.ClickFunc = () =>
       {   //unlock skill depend on field skill in inspector
           //    Debug.Log(playerAbHolder);
           //    Debug.Log(playerAbHolder.GetSkill(Skill));
           playerAbHolder.UnLockSkill(AbilityHolder.GetSkill(Skill));
           if (playerAbHolder.IsUnlockSkill(AbilityHolder.GetSkill(Skill)) == true) transform.Find("Cooldown").gameObject.SetActive(false);


       };
        this.InitBtn();
    }
    void InitBtn()
    {
        Ability thisAbi = AbilityHolder.GetSkill(Skill);
        transform.Find("Skill").GetComponent<Image>().sprite = thisAbi.abilitySO.sprite;
    }

    //get playerABHolder via event
    void SetPlayerAbHolder(AbilityHolder playerAbHolder)
    {
        this.playerAbHolder = playerAbHolder;
    }
}
