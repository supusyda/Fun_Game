using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IClickAble
{
    public void Click()
    {

    }


    // Start is called before the first frame update
    private void OnDrawGizmos()
    {

        // if (!GameManager.Instance.DEBUG) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
        // Gizmos.color = Color.green;
        // Gizmos.DrawLine(startedPos, targetPosition);
        // Gizmos.DrawLine(transform.position, startedPos);
        // Gizmos.DrawLine(startedPos, (transform.position - startedPos).normalized * maxRoamingRange);
    }
}
