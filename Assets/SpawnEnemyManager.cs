using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum WaveState
{

}
public class SpawnEnemyManager : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField] Transform spawnPosHolder;
  [SerializeField] private List<Transform> spawnLocation = new List<Transform>();
  [SerializeField] private float count = 0;
  [SerializeField] private float waveValue = 0;
  [SerializeField] private float HourToSpawn = 7;



  private void Awake()
  {
    loadSpawnPos();
  }
  void loadSpawnPos()
  {
    foreach (Transform pos in spawnPosHolder)
    {
      spawnLocation.Add(pos);
    }
  }
  private void OnEnable()
  {
    TimeManager.OnHoursChange.AddListener(SpawnWhenNight);
  }
  private void OnDisable()
  {
    TimeManager.OnHoursChange.RemoveListener(SpawnWhenNight);
  }

  private void SpawnWhenNight()
  {
    if (TimeManager.Hours != HourToSpawn) return;
    SpawnEnemy();
  }

  void SpawnEnemy()
  {
    float tempValue = waveValue;
    while (waveValue > 0)
    {
      int randEnemy = Random.Range(0, EnemySpawner.Instance.getPrefabCount());
      int enemyCost = 1;
      if (tempValue - enemyCost >= 0)
      {
        tempValue -= enemyCost;
        Transform enemy = EnemySpawner.Instance.SpawnEnemyByIndex(randEnemy, RandomCircle(transform.position, 6f), Quaternion.identity);
        enemy.gameObject.SetActive(true);
        continue;
      }
      break;
    }

  }
  private Vector3 RandomPointOnCircleEdge(float radius)
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
  Vector3 getRandomSpawnPos()
  {
    return spawnLocation[Random.Range(0, spawnLocation.Count)].position;
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
}
