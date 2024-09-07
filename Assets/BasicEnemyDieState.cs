using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyDieState : State<BasicEnemy>
{
    float timeBeforeNextState = 0f;
    float timer;

    BasicEnemy.BasicEnemyAnimationName animationName = BasicEnemy.BasicEnemyAnimationName.Die;

    public override void Enter()
    {
        _owner.PlayAnimation(animationName);
        timeBeforeNextState = _owner.GetAnimDuration(animationName);

        _owner.ForceInvincibility(true);

        TimeManager.Instance.DoLagTime(.2f, 1f);

        timer = 0f;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBeforeNextState)
        {
            _stateMachine.SetState<BasicEnemyReviveState>();
        }
    }
}
