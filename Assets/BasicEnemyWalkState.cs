using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyWalkState : State<BasicEnemy>
{
    public Vector2 distanceToEntity;

    float distanceToAttack = 1f;


    public override void Enter()
    {
        _owner.PlayAnimation(BasicEnemy.BasicEnemyAnimationName.Idle);
    }

    public override void Exit()
    {
        _owner.SetVelocity(Vector2.zero);
    }


    public override void Update()
    {
        _owner.transform.up = _owner.entityToChase.transform.position - _owner.transform.position;

        if (_owner.transform.up == Vector3.down)
        {
            var newRotation = Quaternion.Euler(0f, 0f, 180f);
            _owner.transform.rotation = newRotation;
        }

        float distanceToPlayer = Vector2.Distance(_owner.transform.position, _owner.entityToChase.transform.position);

        if (distanceToPlayer <= distanceToAttack)
        {
            _stateMachine.SetState<BasicEnemySwordAttack>();
        }
        else
        {
            Vector2 direction = (_owner.entityToChase.transform.position - _owner.transform.position).normalized;
            _owner.SetVelocity(direction * _owner.Data.Speed);
        }
    }
}

