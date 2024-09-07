using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoSingleton<FightManager>
{
    [SerializeField] Entity bossEntity;

    public Entity BossEntity { get => bossEntity; }
}
