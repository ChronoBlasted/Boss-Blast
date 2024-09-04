using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : AttackSystem
{
    [SerializeField] InputActionReference attack;

    PlayerAnimator animator;

    private void Awake()
    {
        animator = PlayerManager.Instance.PlayerAnimator;
    }

    private void OnEnable()
    {
        attack.action.performed += Attack;
    }

    private void OnDisable()
    {
        attack.action.performed -= Attack;
    }

    void Attack(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("SwordAttack");
    }

    public override void Attack(Entity entityDefender)
    {
        base.Attack(entityDefender);

        TimeManager.Instance.DoLagTime();

        CameraManager.Instance.ShakeCamera(2, .075f);
    }
}
