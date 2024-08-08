using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private Vector3 targetPosition = Vector3.zero;
    [SerializeField] float speed = 1f;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {

    }
    public void MoveToDir(Vector3 dir)
    {
        // this.targetPosition = target;
        if (dir == Vector3.zero) return;
        rigidbody2D.MovePosition(transform.position + dir * (Time.deltaTime * speed));
    }
    public void StopMoving()
    {
        rigidbody2D.velocity = Vector3.zero;
    }
}
