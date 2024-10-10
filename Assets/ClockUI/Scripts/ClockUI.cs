

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{

    private const float REAL_SECONDS_PER_INGAME_DAY = 60f;

    [SerializeField] private Transform clockHourHandTransform;
    [SerializeField] private Transform clockMinuteHandTransform;
    private Text timeText;
    private float day;

    private void Awake()
    {

    }

    private void Update()
    {
        day += Time.deltaTime / (REAL_SECONDS_PER_INGAME_DAY * TimeManager.Instance.minuteToRealTime);

        float dayNormalized = day % 1f;
    
        float rotationDegreesPerDay = 360f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
        float MinutePerHours = 60f;
        float hoursNormalized = day % MinutePerHours;

        clockHourHandTransform.eulerAngles = new Vector3(0, 0, -hoursNormalized * rotationDegreesPerDay / MinutePerHours);

      
    }

}
