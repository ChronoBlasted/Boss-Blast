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

    public Entity entityToChase;
    public AttackSystem attackSystem;

    [SerializeField] Animator animator;

    FiniteStateMachine<BasicEnemy> _stateMachine;
    //int _phase = 0;

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

    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
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


