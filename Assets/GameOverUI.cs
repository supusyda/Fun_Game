using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Transform gameOverText;
    [SerializeField] Transform winText;
    [SerializeField] Transform holder;

    void OnEnable()
    {
        EventDefine.OnGameOver.AddListener(ShowGameOverUI);
        EventDefine.OnWin.AddListener(ShowWinUI);
        holder.gameObject.SetActive(false);
    }
    void OnDisable()
    {
        EventDefine.OnGameOver.RemoveListener(ShowGameOverUI);
        EventDefine.OnWin.RemoveListener(ShowWinUI);
    }
    void ShowGameOverUI()
    {

        holder.gameObject.SetActive(true);
        winText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);

    }
    void ShowWinUI()
    {
        holder.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(true);
    }

}
