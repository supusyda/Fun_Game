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
    private bool _isFlip;
    private void Awake()
    {
        onStartSwing = new UnityEvent();
        onEndSwing = new UnityEvent();
        // _isFlip = PlayerCtr.movement.IsFlip;s


    }
    public void StartSwing()
    {
        onStartSwing.Invoke();
    }
    public void EndSwing()
    {
        onEndSwing.Invoke();
    }
    // this func is call in animation event
    public void SpawnSlash()
    {
        
        var offSetSpawnPosX = .59f;
        Transform spawnOjb = ProjectileSpawner.Instance.SpawnThing(transform.position + new Vector3(offSetSpawnPosX * (PlayerCtr.movement.IsFlip == true ? -1 : 1), 0, 0), transform.rotation, ProjectileSpawner.Instance.SLASH_EFFECT);

        spawnOjb.gameObject.SetActive(true);
    }
}
