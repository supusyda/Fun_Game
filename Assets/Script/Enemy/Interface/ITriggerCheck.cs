using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  ITriggerCheck 
{
    // Start is called before the first frame update
   bool isArgo { get; set; }
   bool isAttackWithInRange { get; set; }
   bool isAttackWithInLongRange { get; set; }
    void setIsArgo(bool isArgo);
    void setAttackWithInRange(bool isAttackWithInRange);
    void setAttackWithInLongRange(bool isAttackWithInLongRange);

}
