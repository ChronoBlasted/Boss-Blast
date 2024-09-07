using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyStartBattleState : State<BasicEnemy>
{
    float timeBeforeNextState = 0f;
    float timer = 0f;

    BasicEnemy.BasicEnemyAnimationName animationName = BasicEnemy.BasicEnemyAnimationName.StartBattle;

    public override void Enter()
    {
        _owner.PlayAnimation(animationName);
        timeBeforeNextState = _owner.GetAnimDuration(animationName);

        UIManager.Instance.GameView.UpdatePhase(_owner.Phase); // For first turn
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBeforeNextState)
        {
            _stateMachine.SetState<BasicEnemyIdleState>();
        }
    }
}
