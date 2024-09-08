using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "ScriptableObjects/NewWeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public int id = 0;
    public WeaponType Type = WeaponType.NONE;
    public Sprite Sprite;

    public float Damage = 10f;
    public float FireRate = 1f;
    public int CritChance = 1;
    public int CritDamage = 2;
    public Vector2 Range = new Vector2(.5f, 2f);
    public float Knockback = 1f;
}

public enum WeaponType
{
    NONE,
    SWORD,
    BOW
}
