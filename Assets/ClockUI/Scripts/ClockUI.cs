/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

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
        // clockHourHandTransform = transform.Find("hourHand");
        // clockMinuteHandTransform = transform.Find("MinuteHand");
        // timeText = transform.Find("timeText").GetComponent<Text>();
    }

    private void Update()
    {
        day += Time.deltaTime / (REAL_SECONDS_PER_INGAME_DAY * TimeManager.Instance.minuteToRealTime);

        float dayNormalized = day % 1f;
        // if (dayNormalized >= 1)
        // {
        //     day = 0;
        //     return;
        // }
        float rotationDegreesPerDay = 360f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
        float MinutePerHours = 60f;
        float hoursNormalized = day % MinutePerHours;

        clockHourHandTransform.eulerAngles = new Vector3(0, 0, -hoursNormalized * rotationDegreesPerDay / MinutePerHours);

        // string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

        // float minutesPerHour = 60f;
        // string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        // timeText.text = hoursString + ":" + minutesString;
    }

}
