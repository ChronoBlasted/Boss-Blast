using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityData", menuName = "ScriptableObjects/NewEntityData", order = 0)]
public class EntityData : ScriptableObject
{
    public Color ColorEntity;

    public List<float> MaxHealth = new List<float>
    {
        100,
    };
    public List<float> HealthPerSecond = new List<float>
    {
        .1f,
    };

    public List<float> KnockbackMultiplier = new List<float>
    {
        1f,
    };

    public List<float> InvicibilityTimeStamp = new List<float>
    {
        .5f,
    };

    public List<float> Speed = new List<float>
    {
        5f,
    };

    public List<float> DashSpeed = new List<float>
    {
        20f,
    };
}
