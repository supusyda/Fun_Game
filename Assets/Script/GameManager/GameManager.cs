using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Start is called before the first frame update
  static GameManager instance;
  public static GameManager Instance { get => instance; }
  [SerializeField] FadeUI fade;
  [SerializeField] public bool DEBUG = true;
  private void Awake()
  {
    if (instance != null) return;
    instance = this;
  }
  private void Start()
  {
    fade.FadeOut();
    // AudioManager.Instance?.PlayBGMusic();
    // EnemySpawner.Instance.SpawnThing(Vector3.zero, Quaternion.identity, EnemySpawner.Instance.ENEMY).gameObject.SetActive(true);
    // EnemySpawner.Instance.SpawnThing(Vector3.zero, Quaternion.identity, EnemySpawner.Instance.ENEMY).gameObject.SetActive(true);
    // EnemySpawner.Instance.SpawnThing(Vector3.zero, Quaternion.identity, EnemySpawner.Instance.ENEMY).gameObject.SetActive(true);
  }
}
