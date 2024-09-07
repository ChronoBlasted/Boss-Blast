using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyReviveState : State<BasicEnemy>
{
    float timeBeforeNextState = 0f;
    float timer;

    BasicEnemy.BasicEnemyAnimationName animationName = BasicEnemy.BasicEnemyAnimationName.Revive;

    public override void Enter()
    {
        timeBeforeNextState = _owner.GetAnimDuration(animationName);

        _owner.PlayAnimation(animationName);
        _owner.SetHealth(_owner.Data.MaxHealth);
        _owner.Phase++;

        UIManager.Instance.GameView.UpdateBossHealth(_owner.Data.MaxHealth, timeBeforeNextState);
        UIManager.Instance.GameView.UpdatePhase(_owner.Phase);

        timer = 0f;
    }

    public override void Exit()
    {
        _owner.ForceInvincibility(false);
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBeforeNextState)
        {
            _stateMachine.SetState<BasicEnemyStartBattleState>();
        }
    }
}
