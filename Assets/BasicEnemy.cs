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

    public Entity entityToChase;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    private void Start()
    {
        _stateMachine = new FiniteStateMachine<BasicEnemy>(this);

        _stateMachine.AddState(new BasicEnemyIdleState());
        _stateMachine.AddState(new BasicEnemyWalkState());
        _stateMachine.AddState(new BasicEnemySwordAttack());

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

    public void SetVelocity(Vector2 newVelocity)
    {
        rb.velocity = newVelocity;
    }
}


