using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    [SerializeField] Collider2D attack1Colider;
    [SerializeField] float attackCoolDownTimer = 0;//count to zero
    [SerializeField] float maxAttackCoolDown = 1;


    private void Start()
    {
        PlayerCtr.PlayerInput.Combat.Attack.performed += _ => Attack();
        PlayerAnimationEmitEvent.OnStartSwing.AddListener(OnStartSwing);
        PlayerAnimationEmitEvent.OnEndSwing.AddListener(OnEndSwing);
        this.attackCoolDownTimer = maxAttackCoolDown;

    }
    private void Update() {
        if (attackCoolDownTimer >= maxAttackCoolDown) return;
         attackCoolDownTimer += Time.deltaTime;
    }
    private void OnStartSwing()
    {
        attack1Colider.enabled = true;
    }
    private void OnEndSwing()
    {
        attack1Colider.enabled = false;
    }
    public void flipAttackColider()
    {
        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
    }
    void Attack()
    {   if (attackCoolDownTimer < maxAttackCoolDown) return;
        attackCoolDownTimer = 0;
        PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.Attack);  //    animator

    }

}

