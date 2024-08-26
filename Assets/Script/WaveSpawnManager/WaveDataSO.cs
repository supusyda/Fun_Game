using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDataSO : ScriptableObject
{
    // Start is called before the first frame update
    // the spawn currency work like a shop with each enemySpawn spawn currency will reduce equal to the enemy cost
    public float spawnCurrency;
    public float timeBetweenEachSpawn;
    public List<Transform> enemyCanBeSpawn = new List<Transform>();
    

  
}
