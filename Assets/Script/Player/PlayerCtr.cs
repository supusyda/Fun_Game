using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtr : MonoBehaviour, IClickAble
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
    public static Shooter shooter;
    static public Level myLevel { get; set; }
    public static stat Stat = new(5, 10);
    public static DamageReciver myHealth;
    public static PlayerMovement movement;
    public static float modifiedAttackSpeed;
    public enum PlayerState
    {
        Idle,
        Moving,

        GetHit,

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
        shooter = GetComponent<Shooter>();
        myLevel = new();
        Stat = new(10, 5);//temp stat for now
        myHealth = GetComponentInChildren<DamageReciver>();
        movement = GetComponent<PlayerMovement>();
        modifiedAttackSpeed = 1;




    }
    private void Start()
    {
        LevelBar.OnCompleteLoadPlayerLevel?.Invoke(myLevel);
    }
    private void OnEnable()
    {
        PlayerInput.Enable();
        myLevel.OnLevelChange.AddListener(OnLevelUp);
    }
    private void OnDisable()
    {
        PlayerInput.Disable();
        myLevel.OnLevelChange.RemoveListener(OnLevelUp);
    }
    void OnLevelUp()
    {

        Transform spawnParticle = ParticalSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ParticalSpawner.Instance.LEVELUP_PARTICLE);
        spawnParticle.parent = transform;
        spawnParticle.gameObject.SetActive(true);
        AudioManager.Instance.PlayAudio(AudioManager.Instance._LEVELUP);
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
                PlayerCtr.PlayerAnimator.speed = 1f;

                newAnimateState = PlayerDefine.Player_Idle;
                break;
            case PlayerState.Moving:
                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION)) return;
                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION_2)) return;
                PlayerCtr.PlayerAnimator.speed = 1f;


                newAnimateState = PlayerDefine.Player_running;
                break;
            case PlayerState.Attack:

                if (CheckAnimationStateIsPlaying(PlayerDefine.PLAYER_ATTACK_ANIMATION_2)) return;
                playerAttack.ComboAttack();





                break;
            case PlayerState.GetHit:
                PlayerMovement.LockMovementForTime(500);
                break;


        }


        if (newAnimateState == "") return;
        _currentState = newState;

        if (_currentState == PlayerState.Attack) return;
        PlayerAnimator.Play(newAnimateState);
    }

    public void Click()
    {
        EventDefine.OnClickOnPlayer?.Invoke();
    }
    public static void SetAttackSpeed(float speed)
    {
        modifiedAttackSpeed = speed;
    }
    public static float getModifedAttackSpeed()
    {
        return modifiedAttackSpeed;
    }
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Z))
    //     {
    //         OnLevelUp();
    //     }
    // }
}
