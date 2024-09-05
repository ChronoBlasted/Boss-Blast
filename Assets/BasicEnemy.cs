using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasicEnemy : Entity
{
    public enum BasicEnemyAnimationName
    {
        None,
        Idle,
        SwordAttack
    }

    FiniteStateMachine<BasicEnemy> _stateMachine;

    [SerializeField] Animator animator;

    private void Start()
    {
        _stateMachine = new FiniteStateMachine<BasicEnemy>(this);
        _stateMachine.AddState(new BasicEnemyIdleState());
        _stateMachine.SetState<BasicEnemyIdleState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void PlayAnimation(BasicEnemyAnimationName animationName)
    {
        animator.Play(animationName.ToString());
    }
}


