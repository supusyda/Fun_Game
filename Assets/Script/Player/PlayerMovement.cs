using System;
using System.Collections;
using System.Collections.Generic;
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
    float moveSpeed = 1f;


    private bool IsFlip
    {
        get => _isFlip;
        set
        {
            _isFlip = value;
            isInFlipAnim = true;
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


    private void FixedUpdate()
    {

        moveDirection = PlayerCtr.PlayerInput.Movement.Move.ReadValue<Vector2>();
        Move();

    }
    void flipPlayer()
    {

        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (isInFlipAnim == true) return;
        if (mousePos.x < playerScreenPoint.x && !IsFlip)
        {
            IsFlip = true; return;
        }
        if (mousePos.x > playerScreenPoint.x && IsFlip)
        {
            IsFlip = false;
        }
    }



    void Move()
    {
        flipPlayer();
        if (moveDirection.x != 0 || moveDirection.y != 0) PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.Moving);
        else PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.Idle);
        if (PlayerCtr.CurrentState != PlayerCtr.PlayerState.Moving) return;



        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveDirection * (Time.deltaTime * moveSpeed));

    }
}