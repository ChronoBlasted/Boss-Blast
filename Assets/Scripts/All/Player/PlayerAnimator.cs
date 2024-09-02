using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void SetTrigger(string paramName)
    {
        animator.SetTrigger(paramName);
    }

    public void SetBool(string paramName, bool value)
    {
        animator.SetBool(paramName, value);
    }

    public void SetFloat(string paramName, float value)
    {
        animator.SetFloat(paramName, value);
    }

    public float GetFloat(string paramName)
    {
        return animator.GetFloat(paramName);
    }
}
