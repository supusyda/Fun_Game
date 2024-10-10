using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateTxt : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();

    }
    public void SetText(string text)
    {
        if (this.text == null) return;
        this.text.text = text;
    }
}
