using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] WeaponData currentWeapon;
    [SerializeField] BoxCollider2D attackTrigger;
    [SerializeField] SpriteRenderer weaponRenderer;

    public virtual void Attack(Entity entityDefender)
    {
        entityDefender.TakeDamage(currentWeapon.Damage);

        Vector2 forceKnockback = (entityDefender.transform.position + (entityDefender.transform.position - transform.position)) * currentWeapon.Knockback * entityDefender.Data.KnockbackMultiplier;

        if (forceKnockback != Vector2.zero) entityDefender.transform.DOMove(forceKnockback, .5f);
    }

    public virtual void EquipWeapon(WeaponData newWeapon)
    {
        if (newWeapon == currentWeapon) return;

        currentWeapon = newWeapon;

        attackTrigger.size = attackTrigger.size;
        attackTrigger.offset = new Vector2(0f, attackTrigger.size.y / 2f);

        weaponRenderer.sprite = currentWeapon.Sprite;
    }
}
