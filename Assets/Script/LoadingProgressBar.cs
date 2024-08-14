using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Image image;
    [SerializeField] private float _timeToDrain = 0.25f;
    private float _target;

    private void Awake() {
        image = transform.GetComponent<Image>();
    }
    private void Start() {
        StartCoroutine(DrainHealthBar());
    }
    private void Update() {
        _target = Loader.GetProgressLoading();
        
    }
        IEnumerator DrainHealthBar()
    {

        float elapedTime = 0;
        while (elapedTime < _timeToDrain)
        {
            elapedTime += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(image.fillAmount, _target, elapedTime / _timeToDrain);
            yield return null;
        }
    }
}
