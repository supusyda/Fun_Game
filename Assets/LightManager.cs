using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Light2D globalLight;
    [SerializeField] private bool _isDay = false;
    private bool isSwitching = false;
    private int _timeToTurnNight = 19;
    private int _timeToTurnMorning = 5;
    [SerializeField] private float timeToSwitch = 5;
    [SerializeField] private Transform _twenkel;

    private void Start()
    {
        globalLight.intensity = _isDay ? .8f : .05f;
    }
    private void OnEnable() 
    {
        TimeManager.OnHoursChange.AddListener(SwitchLight);
    }
    private void OnDisable()
    {
        TimeManager.OnHoursChange.AddListener(SwitchLight);
    }
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     if (isSwitching) return;
        //     StartCoroutine(StartToggelLight());
        // }
    }
    void SwitchLight()
    {
        if (TimeManager.Hours == _timeToTurnMorning || TimeManager.Hours == _timeToTurnNight)
        {
            StartCoroutine(StartToggelLight());
            _twenkel.gameObject.SetActive(!_isDay);

        }
    }
    IEnumerator StartToggelLight()
    {
        float elapedTime = 0;
        float currentTarget = globalLight.intensity;
        _isDay = !_isDay;

        float lerpTarget = _isDay ? .8f : 0.05f;
        isSwitching = true;
        while (elapedTime <= timeToSwitch)
        {
            elapedTime += Time.deltaTime;
            globalLight.intensity = Mathf.Lerp(currentTarget, lerpTarget, elapedTime / timeToSwitch);
            yield return null;
        }
        isSwitching = false;

    }
}
