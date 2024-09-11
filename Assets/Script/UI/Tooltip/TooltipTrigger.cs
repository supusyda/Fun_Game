using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string content;
    public string header;
    public void OnPointerEnter(PointerEventData eventData)
    {
        // delay = LeanTween.delayedCall(0.3f, () =>
        //  {
        //      TooltipSystem.Show(content, header);

        //  });
        TooltipSystem.Show(content, header);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }

    // Start is called before the first frame update

}
