using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class GameScneceUI : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        transform.Find("StartBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.LoadScene(Loader.Scene.GameScene);
        };
    }
}
