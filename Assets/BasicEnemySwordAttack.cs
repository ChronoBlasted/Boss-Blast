using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySwordAttack : State<BasicEnemy>
{
    float attackDuration = 1f;
    float distanceToAttack = 1f;
    float attackTimer;

    public override void Enter()
    {
        Attack();
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
        _owner.PlayAnimation(BasicEnemy.BasicEnemyAnimationName.SwordAttack);
        attackTimer = 0f;
    }

    public override void Exit()
    {
    }
}


