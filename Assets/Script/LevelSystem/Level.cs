using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class Level
{
    public UnityEvent OnExpChange = new();
    public UnityEvent OnLevelChange = new();
    private static readonly int[] expPerlevel = new[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    public int level;
    public float exp;
    public int skillPoint;
    // public float expToNextLevel;
    public void Awake()
    {
        // expToNextLevel = 100;
    }
    public Level()
    {

        level = 0;
        exp = 0;
        skillPoint = 0;
    }
    public void AddExp(int amount)
    {
        if (IsMaxLevel()) return;
        exp += amount;


        while (!IsMaxLevel() && exp >= GetEXPToNextLvl(level))
        {

            exp = exp - GetEXPToNextLvl(level);
            level++;

            OnLevelChange?.Invoke();
        }

        OnExpChange?.Invoke();
    }



    public int GetLevel()
    {
        return level;
    }
    public float GetEXP()
    {
        return (float)exp / GetEXPToNextLvl(level);
    }
    public float GetEXPToNextLvl(int level)
    {
        if (level <= expPerlevel.Length)
        {
            return expPerlevel[level];

        }
        else
        {
            Debug.LogError("Level invalid" + level);
            return 100;
        }
    }
    bool IsMaxLevel()
    {
        return level == expPerlevel.Length - 1;
    }

}
