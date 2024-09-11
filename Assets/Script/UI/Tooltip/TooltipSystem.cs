using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem instance;
    public Tooltip tooltip;
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
    public static void Hide()
    {

        instance.tooltip.gameObject.SetActive(false);
    }
}
