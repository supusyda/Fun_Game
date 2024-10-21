using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SkillPointUIText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text skillPoint;
    [SerializeField] private AbilityHolder abilityHolder;
    public static UnityEvent<int> onSkillPointChange = new();
    void OnEnable()
    {
        onSkillPointChange.AddListener(SetSkillPoint);
        SetSkillPoint((int)abilityHolder.GetSkillPointToUnlock());
    }
    void OnDisable()
    {
        onSkillPointChange.RemoveListener(SetSkillPoint);
    }
    void Awake()
    {
        skillPoint = GetComponent<TMP_Text>();
    }
    void SetSkillPoint(int point)
    {
        skillPoint.text = "Skill Point:" + point.ToString();
    }
}
