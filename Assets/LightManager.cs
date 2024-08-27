using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Light2D globalLight;
    [SerializeField] private bool _isDay = true;
    private int _timeToTurnNight = 19;
    private int _timeToTurnMorning = 5;
    private float timeToSwitch = 5;


    private void OnEnable()
    {
        TimeManager.OnHoursChange.AddListener(ChangeLightToNight);
    }
    private void OnDisable()
    {
        TimeManager.OnHoursChange.AddListener(ChangeLightToNight);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            StartCoroutine(StartToggelLight());
        }
    }
    void ChangeLightToNight()
    {
        // if (TimeManager.Hours >)
    }
    IEnumerator StartToggelLight()
    {
        float elapedTime = 0;
        float lerpTarget = _isDay ? 0.05f : 1;
        while (elapedTime < timeToSwitch)
        {
            elapedTime += Time.deltaTime;
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, lerpTarget, elapedTime / timeToSwitch);
            yield return null;
        }
        _isDay = !_isDay;

    }
}
