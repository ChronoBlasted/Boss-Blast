using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityData", menuName = "ScriptableObjects/NewEntityData", order = 0)]
public class EntityData : ScriptableObject
{
    public Color ColorEntity;
    public int MaxPhase;

    [Header("Phase")]
    public List<float> MaxHealth = new List<float>
    {
        100f,
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

    [Space(30)]
    [Header("Prestige")]
    public List<float> MaxHealthPerPrestige = new List<float>
    {
        1000f,
    };
    public List<float> HealthPerSecondPerPrestige = new List<float>
    {
        1f,
    };

    public List<float> KnockbackMultiplierPerPrestige = new List<float>
    {
        2f,
    };

    public List<float> InvicibilityTimeStampPerPrestige = new List<float>
    {
        1f,
    };

    public List<float> SpeedPerPrestige = new List<float>
    {
        10f,
    };

    public List<float> DashSpeedPerPrestige = new List<float>
    {
        50f,
    };
}
