using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    private void Awake()
    {

    }
    private bool alowRun1Frame = true;
    public void FadeInToBlack(Func<Null> callback = null)
    {

        transform.GetComponent<Image>().DOFade(1f, 1f).onComplete += () =>
        {
            Debug.Log("FADE");
            if (callback != null)
                callback();
            Loader.asyncOperation.allowSceneActivation = true;


        };
    }
    public void FadeOut()
    {
        transform.GetComponent<Image>().DOFade(0f, 1f);
        // alowRun1Frame = true;

    }
    private void Update()
    {
        if (Loader.asyncOperation == null) return;
        if (alowRun1Frame == true && Loader.asyncOperation.progress == .9f)
        {
            alowRun1Frame = false;
            FadeInToBlack();
        }


    }
}
