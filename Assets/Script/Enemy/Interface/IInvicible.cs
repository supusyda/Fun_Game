using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInvicible 
{
    // Start is called before the first frame update
    bool isInvicible{ get; set;}
    IEnumerator invincibleIntime(float time);
    void StartCoroutineInvincibleIntime(float time);
}
