using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    FiniteStateMachine<BasicEnemy> _stateMachine;

    private void Start()
    {
        _stateMachine = new FiniteStateMachine<BasicEnemy>(this);
        _stateMachine.AddState(new BasicEnemyIdleState());
        _stateMachine.SetState<BasicEnemyIdleState>();
    }
}
