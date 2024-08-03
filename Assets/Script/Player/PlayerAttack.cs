using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    [SerializeField] Collider2D attack1Colider;

    private void Start()
    {
        PlayerCtr.PlayerInput.Combat.Attack.performed += _ => Attack();
        PlayerAnimationEmitEvent.OnStartSwing.AddListener(OnStartSwing);
        PlayerAnimationEmitEvent.OnEndSwing.AddListener(OnEndSwing);

    }

    private void OnStartSwing()
    {
        attack1Colider.enabled = true;
    }
    private void OnEndSwing()
    {
        attack1Colider.enabled = false;
    }

    void Attack()
    {
        PlayerCtr.ChangeAnimateState(PlayerCtr.PlayerState.Attack);  //    animator
    }

}

