using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class Loader
{
  // Start is called before the first frame update

  //dummy class
  public class Dummy : MonoBehaviour
  {

  }
  static UnityEvent callBack = new UnityEvent();
  public enum Scene
  {
    None,
    GameScene,
    LoadingScene
  }
  static public AsyncOperation asyncOperation;
  public static void LoadScene(Scene scene)
  {
    callBack.AddListener(() =>
    {
      LoadSceneAsync(scene);
      GameObject dummyGO = new GameObject("DUMMY GAME OBJECT");
      dummyGO.AddComponent<Dummy>().StartCoroutine(LoadSceneAsync(scene));

    });
    SceneManager.LoadScene(Scene.LoadingScene.ToString());

  }
  private static IEnumerator LoadSceneAsync(Scene scene)
  {
    yield return null;
    asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
    asyncOperation.allowSceneActivation = false;
    Debug.Log(asyncOperation.progress);
    while (!asyncOperation.isDone)
    {
     
      yield return null;
    }


  }
  public static float GetProgressLoading()
  {
    if (asyncOperation != null)
    {
      return asyncOperation.progress;
    }
    else
    {
      return 1f;
    }

  }
  public static void LoaderCallBack()
  {
    if (callBack != null)
    {
      callBack.Invoke();
      callBack = new UnityEvent();
    }
  }
}
