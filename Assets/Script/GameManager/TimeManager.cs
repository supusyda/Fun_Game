using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviourSingleton<TimeManager>
{
    // Start is called before the first frame update
    [SerializeField] float slowdownLength = 2f;
    [SerializeField] float slowdownFactor = 0.5f;
    [SerializeField] bool isSlowingdown = false;

    private void Update()
    {
        if (!isSlowingdown) return;
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
