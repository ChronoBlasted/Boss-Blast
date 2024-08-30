using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference attack;

    private void OnEnable()
    {
        attack.action.performed += Attack;
    }

    private void OnDisable()
    {
        attack.action.performed -= Attack;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
    }
}
