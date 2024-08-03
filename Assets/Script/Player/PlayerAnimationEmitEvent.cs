using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEmitEvent : MonoBehaviour
{
    // Start is called before the first frame update

    static UnityEvent onStartSwing;
    static UnityEvent onEndSwing;
    public static UnityEvent OnStartSwing { get => onStartSwing; }
    public static UnityEvent OnEndSwing { get => onEndSwing; }
    private void Awake()
    {
        onStartSwing = new UnityEvent();
        onEndSwing = new UnityEvent();
    }
    public void StartSwing()
    {
        onStartSwing.Invoke();
    }
    public void EndSwing()
    {
        onEndSwing.Invoke();
    }
}
