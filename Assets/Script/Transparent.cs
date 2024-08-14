using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTransparent = false;
    public void BeginTraparent()
    {
        if (isTransparent == true) return;
        DOTween.Kill(transform.Find("Model").GetComponent<SpriteRenderer>());

        isTransparent = true;
        transform.Find("Model").GetComponent<SpriteRenderer>().DOFade(0.7f, 1);
    }
    public void End()
    {
        if (isTransparent == false) return;
        DOTween.Kill(transform.Find("Model").GetComponent<SpriteRenderer>());

        isTransparent = false;
        transform.Find("Model").GetComponent<SpriteRenderer>().DOFade(1, 0.5f);
    }
}
