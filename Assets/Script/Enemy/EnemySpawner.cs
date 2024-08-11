using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawn
{
    // Start is called before the first frame update
    public string ENEMY= "Enemy";
    private EnemySpawner instance;
    static public EnemySpawner Instance;
    private void Awake()
    {
        if (instance != null) return;
        Instance = this;
    }
   
}
