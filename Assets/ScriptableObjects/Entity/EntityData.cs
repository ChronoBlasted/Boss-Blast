using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityData", menuName = "ScriptableObjects/NewEntityData", order = 0)]
public class EntityData : ScriptableObject
{
    public float MaxHealth = 100f;
    public float HealthPerSecond = .1f;
    public float KnockbackMultiplier = 1f;
    public float InvicibilityTimeStamp = .5f;

    public float Speed = 5f;
    public float DashSpeed = 20f;
}
