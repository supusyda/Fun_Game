using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerSkillUI;
    private void OnEnable()
    {
        EventDefine.OnClickOnPlayer.AddListener(PlayerSkillPanel);
    }
    private void OnDisable()
    {
        EventDefine.OnClickOnPlayer.RemoveListener(PlayerSkillPanel);

    }
    void PlayerSkillPanel()
    {
       
        playerSkillUI.gameObject.SetActive(true);


    }
}
