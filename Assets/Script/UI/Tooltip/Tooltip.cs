using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode()]

public class Tooltip : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text headerField;
    [SerializeField] private TMP_Text contentField;
    [SerializeField] private LayoutElement layoutElement;
    [SerializeField] private int characterWrapLimit;
    [SerializeField] public RectTransform rectTransform;
    private void OnEnable()
    {
        // LeanTween.easeInBounce(transform.position, transform.position);
        // FadeFinished();
    }
    // void FadeStart()
    // {
    //     LeanTween.alpha(rectTransform, 0f, 1f).setEase(LeanTweenType.linear).setOnComplete(FadeFinished);
    // }
    // void FadeFinished()
    // {
    //     LeanTween.alpha(rectTransform, 1f, 1f).setEase(LeanTweenType.linear).setOnComplete(FadeStart);
    // }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;
            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }
        Vector2 postion = Input.mousePosition;
        float pivotX = postion.x / Screen.width;
        float pivotY = postion.y / Screen.height;
        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = postion;


    }
    public void SetText(string content, string header)
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;

        }
        contentField.text = content;
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;
        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }


}
