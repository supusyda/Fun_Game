using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isFirstFrame = true;
  private void Update() {
    if(_isFirstFrame != true) return;
    _isFirstFrame = false;
        Loader.LoaderCallBack();
  }
}
