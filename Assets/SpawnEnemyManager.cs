using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
enum WaveState
{

}
public class SpawnEnemyManager : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField] private float waveValue = 0;
  [SerializeField] private float HourToSpawn = 7;
  [SerializeField] private int _currentEnemyThisWave = 0;
  [SerializeField] private Transform spawnPosHolder;
  [SerializeField] private List<WaveDataSO> waveDataSOs = new List<WaveDataSO>();
  private List<Transform> spawnLocation = new List<Transform>();
  private int _currentWaveIndex = 0;



  private void Awake()
  {
    loadSpawnPos();
  }
  private void OnEnable()
  {
    TimeManager.OnHoursChange.AddListener(SpawnWhenNight);
    EventDefine.OnEnemyDie.AddListener(OnEnemyDie);
  }
  private void OnDisable()
  {
    TimeManager.OnHoursChange.RemoveListener(SpawnWhenNight);
    EventDefine.OnEnemyDie.RemoveListener(OnEnemyDie);

  }
  private void Start()
  {

  }
  private void loadSpawnPos()
  {
    foreach (Transform pos in spawnPosHolder)
    {
      spawnLocation.Add(pos);
    }
  }

  private void OnEnemyDie()
  {

    this.SetCurrentEnemyCount(this._currentEnemyThisWave - 1);
    if (this._currentEnemyThisWave != 0) return;
    this.LoadWaveSO(_currentWaveIndex + 1);
  }


  private void SpawnWhenNight()
  {
    if (TimeManager.Hours != HourToSpawn) return;
    LoadWaveSO(_currentWaveIndex);
  }
  private void LoadWaveSO(int waveIndex)
  {
    Debug.Log("LoadWaveSO");
    this._currentWaveIndex = waveIndex;
    Debug.Log(this._currentWaveIndex);
    if (this._currentWaveIndex > waveDataSOs.Count - 1) { Debug.Log("YOU WIN"); return; }
    SpawnEnemy(waveDataSOs[this._currentWaveIndex]);

  }
  void SpawnEnemy()
  {
    float tempValue = waveValue;
    while (waveValue > 0)
    {
      int randEnemy = Random.Range(0, EnemySpawner.Instance.getPrefabCount());
      int enemyCost = 0;
      if (tempValue - enemyCost > 0)
      {
        Transform enemy = EnemySpawner.Instance.SpawnEnemyByIndex(randEnemy, RandomCircle(transform.position, 6f), Quaternion.identity);
        enemy.gameObject.SetActive(true);
        enemyCost = enemy.GetComponent<EnemyBase>().Cost;
        tempValue -= enemyCost;
        continue;
      }
      break;
    }

  }
  void SpawnEnemy(WaveDataSO waveData)
  {
    int thisWaveCurrency = (int)(0 + waveData.spawnCurrency);


    List<Transform> listOfEnemies = GetRandomEnemyWithInCurency(waveData, thisWaveCurrency);
    SetCurrentEnemyCount(listOfEnemies.Count);
    foreach (Transform enemy in listOfEnemies)
    {
      
      Transform spawnEnemy = EnemySpawner.Instance.SpawnThing(RandomCircle(transform.position, 6f), Quaternion.identity, enemy.name);
      spawnEnemy.gameObject.SetActive(true);
    }
  }
  private void SetCurrentEnemyCount(int value)
  {
    _currentEnemyThisWave = value;
  }
  List<Transform> GetRandomEnemyWithInCurency(WaveDataSO waveData, int currency)
  {
    // formula : this wave currency = this wave currency - enemyInThisWave.cost
    //stop when  this wave currency = 0 or dont have any enemy that make thisWaveCurrency < 0;
    // EX :10(TWC) = 10(TWC)-11(ENEMY.COST) = -1(wrong) ;remove out of enemy list then do again
    List<Transform> currentWayDataPrefab = new List<Transform>(waveData.enemyCanBeSpawn);//this wave enemy list
    List<Transform> selectedEnemies = new();// held selected enemy 
    int retryTime = 5;// need inovation
    waveValue = currency;
    int newCurrency = currency;// wave value get from SO
    while (true)
    {
      int randEnemyIndex = Random.Range(0, currentWayDataPrefab.Count);//get rand enemy
      int enemyCost = currentWayDataPrefab[randEnemyIndex].GetComponent<EnemyBase>().Cost;//get enemy  cost
      // newCurrency -= enemyCost;
      int afterCostCurrency = newCurrency - enemyCost; //current curency after - the enemy cost
      if (afterCostCurrency >= 0) //enemy fullied the codition 
      {
        selectedEnemies.Add(currentWayDataPrefab[randEnemyIndex]);// add to list enemy spawn
        newCurrency = afterCostCurrency;// save the currency
        // Debug.Log("FIRST");
        // Debug.Log(currentWayDataPrefab[randEnemyIndex].name);
        // // Debug.Log(selectedEnemies);
        // Debug.Log("afterCostCurrency" + afterCostCurrency);
        // Debug.Log("newCurrency" + newCurrency);
        if (newCurrency == 0) break;//if cant not get any enemy anymore then return
        continue;
      }
      // else if (afterCostCurrency == 0)
      // {
      //   break;
      // }

      if (currentWayDataPrefab.Count > 0 && retryTime > 0) //enemy not fullfied 
      {
        // Debug.Log("SECOND");
        // Debug.Log("randEnemyIndex" + randEnemyIndex);
        // Debug.Log("newCurrency" + newCurrency);
        // Debug.Log("enemyCost" + enemyCost);
        currentWayDataPrefab.RemoveAt(randEnemyIndex);
        retryTime--;
        if (currentWayDataPrefab.Count <= 0) break;// if dont have anymore enemy that suitable return
        continue;
      }


    }
    return selectedEnemies;

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
