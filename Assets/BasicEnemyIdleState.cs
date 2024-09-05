using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyIdleState : State<BasicEnemy>
{
    public override void Enter()
    {
        _owner.PlayAnimation(BasicEnemy.BasicEnemyAnimationName.Idle);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }
}
