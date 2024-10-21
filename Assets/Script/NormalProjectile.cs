using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : MonoBehaviour, IMoveAle
{
    // Start is called before the first frame update

    [SerializeField] protected float bulletSpeed = 5;
    [SerializeField] protected Vector3 direction = Vector3.right;
    private HitCamBound hitCamBound;
    private bool _alowBounce = false;


    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; }
    public float speed { get; set; }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        // hitCamBound = new HitCamBound(transform);
    }
    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // hitCamBound.UpdateCurrentPos();
        // hitCamBound.AdjustForCameraMovement();
        // if (_alowBounce == false)
        // {
        //     if (hitCamBound.IsHitBoundX())
        //     {
        //         direction.x *= -1;
        //         UpdateRotation();
        //     }
        //     if (hitCamBound.IsHitBoundY())
        //     {
        //         direction.y *= -1;
        //         UpdateRotation();
        //     }
        // }
        // Move(direction);
    }
    void UpdateRotation()
    {
        // Tính toán góc quay dựa trên hướng hiện tại của viên đạn
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Áp dụng góc quay cho viên đạn (thường là trục Z)
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public void SetRotationAndDir(Quaternion rotation, Vector3 Dir)
    {
        direction = Dir;
        transform.rotation = rotation;
    }

    public void Move(Vector3 dir)
    {
        RB.MovePosition(RB.position + (Vector2)dir * (Time.deltaTime * bulletSpeed));
    }

    public void CheckForFaceDir(Vector2 dir)
    {

    }

    public void Move(Vector2 dir)
    {

    }
}
