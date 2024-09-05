using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] WeaponData currentWeapon;
    [SerializeField] SpriteRenderer weaponRenderer;
    [SerializeField] protected AttackTrigger attackTrigger;

    protected bool canAttack = false;
    float lastAttack;

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

        attackTrigger.AttackTriggerCollider.size = attackTrigger.AttackTriggerCollider.size;
        attackTrigger.AttackTriggerCollider.offset = new Vector2(0f, attackTrigger.AttackTriggerCollider.size.y / 2f);

        weaponRenderer.sprite = currentWeapon.Sprite;
    }

    private void Update()
    {
        if (Time.time > currentWeapon.FireRate + lastAttack)
        {
            lastAttack = Time.time;
            canAttack = true;
        }
    }
}
