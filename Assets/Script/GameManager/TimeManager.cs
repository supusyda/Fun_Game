using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviourSingleton<TimeManager>
{
    // Start is called before the first frame update
    [SerializeField] float slowdownLength = 2f;
    [SerializeField] float slowdownFactor = 0.5f;
    [SerializeField] bool isSlowingdown = false;
    

    public static UnityEvent OnMinuteChange = new UnityEvent();
    public static UnityEvent OnHoursChange = new UnityEvent();
    public float minuteToRealTime = 0.1f;
    [SerializeField] float timer = 0;
    [SerializeField] public static float Hours { get; private set; }
    [SerializeField] public static float Minute { get; private set; }
    [SerializeField] public static float Days { get; private set; }



    private void Start()
    {
        timer = minuteToRealTime;
        Hours = 0;
        Minute = 0;
        Days = 0;
    }

    private void Update()
    {

        if (isSlowingdown == true)
        {
            UpdateSlowdownTime();
        }
        UpdateTime();
        // Debug.Log("Hours:" + Hours + " Minute: " + Minute);

    }
    void UpdateTime()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return;
        Minute++;
        OnMinuteChange?.Invoke();
        timer = minuteToRealTime;
        if (Minute < 60) return;
        Hours++;
        Minute = 0;
        OnHoursChange?.Invoke();

        if (Hours < 24) return;
        Days++;
        Hours = 0;


    }
    void UpdateSlowdownTime()
    {
        // if (!isSlowingdown) return;
        Debug.Log(Time.timeScale);
        Time.timeScale += 1 / slowdownLength * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        if (Time.timeScale == 1)
        {

            isSlowingdown = false;
            Time.fixedDeltaTime = 0.02f;

        }
    }
    public void SlowDownTime()
    {

        Debug.Log("SLOW TIME");
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        isSlowingdown = true;
    }
}
