using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTarget : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;


    // Update is called once per frame

    void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        Vector3 tarPosFixZ = new Vector3(this.target.transform.position.x, this.target.transform.position.y, 0);
        transform.position = Vector3.Lerp(transform.position, tarPosFixZ, Time.fixedDeltaTime * speed);

    }
}
