using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update[]
    [SerializeField] EnemyBase enemyBase;
    public void StateAnimationEvent(EnemyBase.AnimationTriggerEvent animationTriggerEvent)
    {

        // enemyBase.enemyStateMachine.AnimationTrigger();
        enemyBase.AnimationTrigger(animationTriggerEvent);
    }
}
