using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewSpawner : Spawn
{
    // Start is called before the first frame update
    public string CREW = "Crew";
    private CrewSpawner instance;
    static public CrewSpawner Instance;
    private void Awake()
    {
        if (instance != null) return;
        Instance = this;
    }
    public int getPrefabCount()
    {
        return prefabs.Count;
    }
    public virtual Transform SpawnEnemyByIndex(int prefabIndex, Vector3 spawnPos, Quaternion direction)
    {
        string prefabName = prefabs[prefabIndex].name;
        return SpawnThing(spawnPos, direction, prefabName);

    }
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        // create random angle between 0 to 360 degrees
        bool correctSpawn = false;
        int searchCount = 10;
        Vector3 pos = Vector3.zero;

        while (searchCount-- > 0 && !correctSpawn)
        {
            var ang = Random.value * 360;

            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            pos.z = center.z;
            correctSpawn = CheckIfPositionIsOcuppied(pos);
        }
        return pos;
    }
    public static Vector3 RandomPointOnCircleEdge(float radius)
    {

        bool correctSpawn = false;

        Vector2 vector2 = new Vector2(0, 0);

        //Number of times we will try to search for an empty position
        int searchCount = 10;

        while (searchCount-- > 0 && !correctSpawn)
        {
            vector2 = Random.insideUnitCircle.normalized * radius;

            correctSpawn = CheckIfPositionIsOcuppied(vector2);
        }

        return new Vector3(vector2.x, 0, vector2.y);
    }
    private static bool CheckIfPositionIsOcuppied(Vector2 vector2)
    {
        bool correctSpawn = true;

        Collider[] collidersDetected = Physics.OverlapBox(new Vector3(vector2.x, 0, vector2.y), new Vector3(1, 2, 1f));

        if (collidersDetected.Length != 0)
        {
            foreach (Collider col in collidersDetected)
            {
                if (col.CompareTag("Enemy"))
                {
                    correctSpawn = false;
                }
            }
        }

        return correctSpawn;
    }
    public void SpawnCrewAroundPlayer()
    {

        Transform enemy = CrewSpawner.Instance.SpawnThing(RandomCircle(GameObject.FindGameObjectWithTag("Player").transform.position, .5f), Quaternion.identity, CREW);
        enemy.gameObject.SetActive(true);

    }

}
