using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class SkillUIExitBtn : MonoBehaviour
{
    // Start is called before the first frame update
  [SerializeField]  Transform playersSkillUI;
    private void Awake()
    {
        Button_UI button_UI = GetComponent<Button_UI>();
        button_UI.ClickFunc = () =>
        {
            playersSkillUI.gameObject.SetActive(false);
        };
    }
}
