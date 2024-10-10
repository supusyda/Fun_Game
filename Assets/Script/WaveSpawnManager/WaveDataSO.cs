using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave/WaveData")]

public class WaveDataSO : ScriptableObject
{
    // Start is called before the first frame update
    // the spawn currency work like a shop with each enemySpawn spawn currency will reduce equal to the enemy cost

    public float spawnCurrency;
    public float timeBetweenEachSpawn;
    public List<Transform> enemyCanBeSpawn = new List<Transform>();

    public List<String> GetEnemyString()
    {
        List<String> returnString = new List<String>();
        foreach (var enemy in enemyCanBeSpawn)
        {
            returnString.Add(enemy.name);
        }

        return returnString;
    }


}
