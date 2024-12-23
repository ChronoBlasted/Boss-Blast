using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySwordAttackState : State<BasicEnemy>
{
    float attackDuration;
    float distanceToAttack = 1f;
    float attackTimer;

    BasicEnemy.BasicEnemyAnimationName animationName = BasicEnemy.BasicEnemyAnimationName.SwordAttack;

    public override void Enter()
    {
        Attack();
        attackDuration = _owner.GetAnimDuration(animationName);
    }

    public override void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            if (Vector2.Distance(_owner.transform.position, _owner.entityToChase.transform.position) > distanceToAttack)
            {
                _stateMachine.SetState<BasicEnemyWalkState>();
            }
            else
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        if (_owner.attackSystem.CanAttack == false) return;
        _owner.attackSystem.CanAttack = false;

        _owner.attackSystem.attackTrigger.Enemies.Clear();

        _owner.PlayAnimation(animationName);
        attackTimer = 0f;
    }

    public override void Exit()
    {
    }
}


