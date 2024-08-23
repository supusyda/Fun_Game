using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float bulletSpeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;
    Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + direction * (Time.deltaTime * bulletSpeed));
    }
    public void SetRotationAndDir(Quaternion rotation,Vector3 Dir)
    {
        direction = Dir;
        transform.rotation = rotation;
    }
}
