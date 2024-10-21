using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartBtn : MonoBehaviour
{
    // Start is called before the first frame update
    private Button restartBtn;
    private void Awake()
    {
        restartBtn = GetComponent<Button>();

    }
    void OnEnable()
    {
        restartBtn.onClick.AddListener(Onclick);
    }
    void OnDisable()
    {
        restartBtn.onClick.RemoveListener(Onclick);
    }
    void Onclick()
    {
        Loader.LoadScene(Loader.Scene.GameScene);
    }

}
