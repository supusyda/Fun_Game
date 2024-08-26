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

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Z))
    {
      SpawnEnemy();
    }
  }
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
        Transform enemy = EnemySpawner.Instance.SpawnEnemyByIndex(randEnemy, getRandomSpawnPos(), Quaternion.identity);
        enemy.gameObject.SetActive(true);
        continue;
      }
      break;
    }

  }
  Vector3 getRandomSpawnPos()
  {
    return spawnLocation[Random.Range(0, spawnLocation.Count)].position;
  }

}
