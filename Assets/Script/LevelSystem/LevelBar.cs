using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LevelBar : MonoBehaviour
{
    // Start is called before the first frame update
    public static UnityEvent<Level> OnCompleteLoadPlayerLevel = new();
    [SerializeField] Text levelText;
    [SerializeField] Image expSlider;
    Level levelSystem;
    private void Awake()
    {
        expSlider = transform.Find("ExpBar").GetComponent<Image>();

    }
    private void OnEnable()
    {
        // levelText = transform.Find("LevelText").GetComponent<Text>();
        OnCompleteLoadPlayerLevel.AddListener((level) =>
        {

            SetLevelSystem(level);


        });


    }
    private void OnDisable()
    {
        OnCompleteLoadPlayerLevel.RemoveListener(SetLevelSystem);
    }
    void SetEXPSilder(float exp)
    {
        expSlider.fillAmount = exp;

    }
    void SetLevelNumber(float levelNum)
    {

        levelText.text = "Level: " + (levelNum + 1).ToString();
    }
    public void OnExpChangeListen()
    {
        Debug.Log("Update exp");
        SetEXPSilder(levelSystem.GetEXP());

    }
    public void OnLevelChangeListen()
    {
        SetLevelNumber(levelSystem.GetLevel());
    }
    public void SetLevelSystem(Level levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevel());
        SetEXPSilder(levelSystem.GetEXP());
        // Debug.Log(levelSystemm.name);
        levelSystem.OnExpChange.AddListener(OnExpChangeListen);
        levelSystem.OnLevelChange.AddListener(OnLevelChangeListen);

    }
}
