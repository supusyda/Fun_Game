using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    // Start is called before the first frame update

    private static PlayerMovement playerMovement;
    public static PlayerMovement PlayerMovement { get => playerMovement; }
    private static PlayerInput playerInput;
    public static PlayerInput PlayerInput { get => playerInput; }
    private static PlayerAttack playerAttack;
    public static PlayerAttack PlayerAttack { get => playerAttack; }
    private static Animator playerAnimator;
    public static Animator PlayerAnimator { get => playerAnimator; }
    private static PlayerState _currentState = PlayerState.Idle;
    public static PlayerState CurrentState { get => _currentState; }
    private static Rigidbody2D rb2D;

    public static Rigidbody2D Rb2D { get => rb2D; }
    private static Transform trail;

    public static Transform Trail { get => trail; }
    public enum PlayerState
    {
        Idle,
        Moving,
        Attack
    }
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimator = transform.Find("Model").GetComponent<Animator>();
        playerAttack = transform.Find("Attack").GetComponent<PlayerAttack>();
        rb2D = GetComponent<Rigidbody2D>();
        trail = transform.Find("Trail");
    }
    private void OnEnable()
    {
        PlayerInput.Enable();
    }
    private void OnDisable()
    {
        PlayerInput.Disable();
    }
    public static bool CheckAnimationStateIsPlaying(string State)
    {

        if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName(State) && PlayerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            return true;
        return false;
    }
    static public void ChangeAnimateState(PlayerState newState)
    {
        string newAnimateState = "";
        switch (newState)
        {

            case PlayerState.Idle:
                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION)) return;
                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION_2)) return;
                newAnimateState = PlayerDefine.Player_Idle;
                break;
            case PlayerState.Moving:
                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION)) return;
                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION_2)) return;


                newAnimateState = PlayerDefine.Player_running;
                break;
            case PlayerState.Attack:

                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION_2)) return;
                playerAttack.ComboAttack();

                break;

                // if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION))
                // {
                //     newAnimateState = PlayerDefine.PLAYER_ATTACK_ANIMATION_2;
                //     break;
                // }
                // newAnimateState = PlayerDefine.PLAYER_ATTACK_ANIMATION;
                // break;
        }


        if (newAnimateState == "") return;
        _currentState = newState;

        if (_currentState == PlayerState.Attack) return;
        PlayerAnimator.Play(newAnimateState);
    }



}
