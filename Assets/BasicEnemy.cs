using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasicEnemy : Entity
{
    public enum BasicEnemyAnimationName
    {
        None,
        StartBattle,
        Idle,
        SwordAttack,
        Revive,
        Die,
    }

    public Entity entityToChase;
    public AttackSystem attackSystem;

    [SerializeField] Animator animator;

    FiniteStateMachine<BasicEnemy> _stateMachine;

    private void Start()
    {
        _stateMachine = new FiniteStateMachine<BasicEnemy>(this);

        _stateMachine.AddState(new BasicEnemyStartBattleState());
        _stateMachine.AddState(new BasicEnemyIdleState());
        _stateMachine.AddState(new BasicEnemyWalkState());
        _stateMachine.AddState(new BasicEnemySwordAttackState());
        _stateMachine.AddState(new BasicEnemyReviveState());
        _stateMachine.AddState(new BasicEnemyDieState());

        _stateMachine.SetState<BasicEnemyStartBattleState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public override void Die()
    {
        base.Die();

        _stateMachine.SetState<BasicEnemyDieState>();
    }

    public void PlayAnimation(BasicEnemyAnimationName animationName)
    {
        animator.Play(animationName.ToString());
    }

    public float GetAnimDuration(BasicEnemyAnimationName basicEnemyAnimationName)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == basicEnemyAnimationName.ToString())
            {
                return clip.length;
            }
        }

        return 0f;
    }

    public void SetVelocity(Vector2 newVelocity)
    {
        rb.velocity = newVelocity;
    }
}


