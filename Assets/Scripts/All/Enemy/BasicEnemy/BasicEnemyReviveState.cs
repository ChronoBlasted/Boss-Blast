using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyReviveState : State<BasicEnemy>
{
    float timeBeforeNextState = 0f;
    float timer;

    int totalPhase = 1;

    BasicEnemy.BasicEnemyAnimationName animationName = BasicEnemy.BasicEnemyAnimationName.Revive;

    public override void Enter()
    {
        timeBeforeNextState = _owner.GetAnimDuration(animationName);

        _owner.PlayAnimation(animationName);

        _owner.Phase++;
        totalPhase++;

        if (_owner.Phase == _owner.Data.MaxPhase)
        {
            _owner.Phase = 0;
            _owner.Prestige++;
        }

        float newMaxHealth = _owner.Data.MaxHealth[_owner.Phase] + _owner.Data.MaxHealthPerPrestige[_owner.Prestige];
        UIManager.Instance.GameView.SetNewMaxHealth(newMaxHealth);
        UIManager.Instance.GameView.UpdateBossHealth(newMaxHealth);

        _owner.SetHealth(newMaxHealth);

        UIManager.Instance.GameView.UpdatePhase(totalPhase);

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
