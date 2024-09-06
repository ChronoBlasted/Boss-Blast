using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyIdleState : State<BasicEnemy>
{
    float randomTimeBeforeWalk;

    public override void Enter()
    {
        _owner.PlayAnimation(BasicEnemy.BasicEnemyAnimationName.Idle);
        randomTimeBeforeWalk = Time.time + Random.Range(1, 5);

    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (Time.time > randomTimeBeforeWalk)
        {
            _stateMachine.SetState<BasicEnemyWalkState>();
        }
    }
}