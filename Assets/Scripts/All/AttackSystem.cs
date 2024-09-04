using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] WeaponData currentWeapon;

    public virtual void Attack(Entity entityDefender)
    {
        entityDefender.TakeDamage(currentWeapon.Damage);

        Vector2 forceKnockback = (entityDefender.transform.position + (entityDefender.transform.position - transform.position)) * currentWeapon.Knockback * entityDefender.Data.KnockbackMultiplier;

        if (forceKnockback != Vector2.zero) entityDefender.transform.DOMove(forceKnockback, .5f);
    }
}
