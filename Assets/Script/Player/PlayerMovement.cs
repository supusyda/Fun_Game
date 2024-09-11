using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    // PlayerInput playerInput;
    Vector2 moveDirection = Vector3.zero;
    Rigidbody2D rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform model;

    private bool _isFlip = false;
    private bool _isLockMoving = false;

    private bool isInFlipAnim = false;

    [SerializeField] private float dashCDTimer = 0;

    float moveSpeed = 1f;


    private bool IsFlip
    {
        get => _isFlip;
        set
        {
            _isFlip = value;
            isInFlipAnim = true;
            PlayerCtr.PlayerAttack.flipAttackColider();
            if (value == false)
            {
                model.DORotate(new Vector3(0, 0, 0), 0.3f).OnComplete(() =>
                {
                    isInFlipAnim = false;
                }); return;
            }
            model.DORotate(new Vector3(0, 180, 0), 0.3f).OnComplete(() =>
            {
                isInFlipAnim = false;
            });


        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        PlayerCtr.PlayerInput.Movement.Dash.performed += _ => Dash();
        dashCDTimer = 0;
        InvokeRepeating(nameof(SpawnDustTrailWhenMoving), 0.1f, 0.5f);
    }
    private void Update()
    {
        if (dashCDTimer <= 0) return;
        dashCDTimer -= Time.deltaTime;

    }

    private void FixedUpdate()
    {

        moveDirection = PlayerCtr.PlayerInput.Movement.Move.ReadValue<Vector2>();
        Move();

    }
    void flipPlayer()
    {


        if (isInFlipAnim == true) return;
        if (isLeftOfPlayer() && !IsFlip)
        {
            IsFlip = true; return;
        }
        if (!isLeftOfPlayer() && IsFlip)
        {
            IsFlip = false;
        }
    }

    bool isLeftOfPlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        return mousePos.x < playerScreenPoint.x;
    }

    void Move()
    {
        if (_isLockMoving == true) return;
        flipPlayer();
        if (moveDirection.x != 0 || moveDirection.y != 0) PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.Moving);
        else PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.Idle);
        if (PlayerCtr.CurrentState != PlayerCtr.PlayerState.Moving) return;
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveDirection * (Time.deltaTime * moveSpeed));

    }
    async void Dash()
    {   //
        if (dashCDTimer > 0) return;
        dashCDTimer = PlayerDefine.player_dash_cool_down;
        // get dir from mosue to player

        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dashDir = (mousePos - playerScreenPoint).normalized;
        dashDir = new Vector3(dashDir.x, dashDir.y, 0) * PlayerDefine.player_dash_speed;
        //dash and lock movement
        PlayerCtr.Trail.gameObject.SetActive(true);
        PlayerCtr.Rb2D.AddForce(dashDir, ForceMode2D.Impulse);
        
        _isLockMoving = true;
        await Task.Delay(500);
        PlayerCtr.Trail.gameObject.SetActive(false);
        // unlock movement and stop dash
        PlayerCtr.Rb2D.velocity = Vector3.zero;
        _isLockMoving = false;
    }
    void SpawnDustTrailWhenMoving()
    {
        if (PlayerCtr.CurrentState != PlayerCtr.PlayerState.Moving) return;

        Vector3 offSetSpawnPos = new Vector3(transform.position.x, transform.position.y - 0.3f, 0);
        ParticalSpawner.Instance.SpawnThing(offSetSpawnPos, Quaternion.identity, ParticalSpawner.Instance.DUST_TRAIL_PARTICLE).gameObject.SetActive(true);

    }
    public void LockMovement()
    {
        _isLockMoving = true;
    }
    public void UnLockMovement()
    {
        _isLockMoving = false;
    }
    public async void LockMovementForTime(int time)
    {
        LockMovement();
        await Task.Delay(time);
        UnLockMovement();

    }
}