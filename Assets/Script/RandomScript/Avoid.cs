using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Avoid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float targetVelocity = 10;
    [SerializeField] int rayNum = 10;
    public float angle = 90;
    public float distant = 10;
    [SerializeField] LayerMask layerMask;
    [SerializeField] EnemyBase enemyBase;
    // public EnemyBase enemyBase;
    // public Vector3 deltaPos
    // {
    //     get; private set;
    // }
    public Vector3 cc2
    {
        get; private set;
    }
    private void Start()
    {
        enemyBase = transform.parent.GetComponent<EnemyBase>();
        // InvokeRepeating("GetAvoidDir", .5f, 1);
    }
    private void Update()
    {



    }
    public Vector3 GetAvoidDir()
    {
        Vector3 deltaPos = Vector3.zero;

        Quaternion rotation = transform.rotation;
        bool isHit = false;
        for (int i = 0; i <= rayNum; i++)
        {
            Quaternion rotationMod = Quaternion.AngleAxis((i / (float)rayNum) * angle * 2 - angle, transform.forward);
            Vector3 dir = rotation * rotationMod * Vector3.right;
            RaycastHit2D raycastHit2Dhit = Physics2D.Raycast(transform.position, dir, distant, layerMask);
            if (raycastHit2Dhit)
            {
                deltaPos -= Math.Clamp((1f / rayNum), 0, 1) * targetVelocity * dir;
            }
            else
            {
                deltaPos += Math.Clamp((1f / rayNum), 0, 1) * targetVelocity * dir;
            }

        }
        return deltaPos.normalized;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        if (!Application.isEditor) return;
        Vector3 cc = Vector3.zero;
        Quaternion rotation = transform.rotation;
        bool isHit = false;
        for (int i = 0; i <= rayNum; i++)
        {
            Quaternion rotationMod = Quaternion.AngleAxis((i / (float)rayNum) * angle * 2 - angle, transform.forward);
            Vector3 dir = rotation * rotationMod * Vector3.right;
            RaycastHit2D raycastHit2Dhit = Physics2D.Raycast(transform.position, dir, distant, layerMask);
            // var ray = new Ray(transform.position, dir);
            // RaycastHit raycastHit;
            if (raycastHit2Dhit)
            {
                cc -= Math.Clamp((1f / rayNum), 0, 1) * targetVelocity * dir;               
            }
            else
            {
                cc += Math.Clamp((1f / rayNum), 0, 1) * targetVelocity * dir;
            }
        }
        // Gizmos.DrawRay(transform.position, enemyBase.moveDir * 5)
        Gizmos.DrawRay(transform.position, cc.normalized * 10);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, ((Vector3)enemyBase.moveDir + cc.normalized).normalized * 10);
        Gizmos.color = Color.white;
        for (int i = 0; i <= rayNum; i++)
        {
            Quaternion rotationMod = Quaternion.AngleAxis((i / (float)rayNum) * angle * 2 - angle, transform.forward);
            Vector3 dir = rotation * rotationMod * Vector3.right;
            Gizmos.DrawRay(transform.position, dir.normalized * distant);
        }

    }

}
