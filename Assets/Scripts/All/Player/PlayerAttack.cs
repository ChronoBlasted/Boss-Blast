using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
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

    public void Attack(Entity entity)
    {
        entity.TakeDamage(10);

        if (entity.tag != "Dummy") entity.transform.DOMove(entity.transform.position + (entity.transform.position - PlayerManager.Instance.transform.position), .5f).SetUpdate(UpdateType.Fixed);

        CameraManager.Instance.ShakeCamera(2, .075f);
    }
}
