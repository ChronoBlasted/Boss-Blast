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
        attack.action.performed += AttackInput;
    }

    private void OnDisable()
    {
        attack.action.performed -= AttackInput;
    }

    void AttackInput(InputAction.CallbackContext obj)
    {
        if (!CanAttack) return;

        CanAttack = false;

        attackTrigger.Enemies.Clear();

        animator.SetTrigger("SwordAttack");
    }

    public override bool Attack(Entity entityDefender)
    {
        if (entityDefender.CanTakeDamage)
        {
            CameraManager.Instance.ShakeCamera(2, .075f);

            if (base.Attack(entityDefender)) TimeManager.Instance.DoLagTime(.1f, .1f);
            else TimeManager.Instance.DoLagTime(.2f, .05f);
        }

        return false;
    }
}
