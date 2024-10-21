using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem instance;
    public Tooltip tooltip;
    public SkillToolTip skillTooltip;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;

        }
    }
    public static void Show(string content, string header = "")
    {
        instance.tooltip.gameObject.SetActive(true);
        instance.tooltip.SetText(content, header);
    }
    public static void ShowSkillToolTip(string content, string header, string skillPontText, string cooldownText, Sprite sprite, bool isUnlock)
    {
        instance.skillTooltip.gameObject.SetActive(true);
        instance.skillTooltip.SetText(content, header, skillPontText, cooldownText, sprite);
        if (isUnlock)
        {
            instance.skillTooltip.OnSkillHasBeenUnlock();
        }
        else
        {
            instance.skillTooltip.OnSkillHasNotBeenUnlock();
        }
        // skillTooltip.
    }
    public static void Hide()
    {

        instance.tooltip.gameObject.SetActive(false);
        instance.skillTooltip.gameObject.SetActive(false);
    }
}
