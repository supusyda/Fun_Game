using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] DamageDealer firstAttack;
   public void enabledFirstAttack()
   {
       firstAttack.hitBox.enabled = true;
   }
   public void disableFirstAttack()
   {
       firstAttack.hitBox.enabled = false;
   }
}
