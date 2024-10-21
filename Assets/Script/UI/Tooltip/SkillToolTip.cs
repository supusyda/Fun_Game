using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillToolTip : Tooltip
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text skillPointField;
    [SerializeField] private TMP_Text cooldownField;
    [SerializeField] private Image skillImage;

    public void SetText(string content, string header, string skillPontText, string cooldownText, Sprite sprite)
    {
        base.SetText(content, header);
        skillPointField.text = skillPontText;
        cooldownField.text = cooldownText;

        int skillPointLength = skillPointField.text.Length;
        int cooldownLength = cooldownField.text.Length;
        skillImage.sprite = sprite;
        layoutElement.enabled = (skillPointLength > characterWrapLimit || cooldownLength > characterWrapLimit) ? true : false;
        ChangeColorSkillPointText(Color.red);
    }

    private void ChangeColorSkillPointText(Color color)
    {
        skillPointField.color = color;
    }
    private void ChangeColorCooldownText(Color color)
    {
        cooldownField.color = color;
    }
    public void OnSkillHasBeenUnlock()
    {
        ChangeColorSkillPointText(Color.green);
    }
    public void OnSkillHasNotBeenUnlock()
    {
        ChangeColorSkillPointText(Color.red);
    }
}
