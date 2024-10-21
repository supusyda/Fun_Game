using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawn
{
    // Start is called before the first frame update
    public string ENEMY = "Enemy";
    public string EOW_ENEMY = "EaterOfWorld";


    private EnemySpawner instance;
    static public EnemySpawner Instance;
    private void Awake()
    {
        if (instance != null) return;
        Instance = this;
    }
    public int getPrefabCount()
    {
        return prefabs.Count;
    }
    public Transform SpawnEnemyByIndex(int prefabIndex, Vector3 spawnPos, Quaternion direction)
    {
        string prefabName = prefabs[prefabIndex].name;
        return SpawnThing(spawnPos, direction, prefabName);

    }

}
