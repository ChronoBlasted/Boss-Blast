using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public AttackTrigger attackTrigger;
    public bool CanAttack = true;

    [SerializeField] WeaponData currentWeapon;
    [SerializeField] SpriteRenderer weaponRenderer;

    float lastAttack;


    public virtual void Attack(Entity entityDefender)
    {
        entityDefender.TakeDamage(currentWeapon.Damage);

        Vector2 directionKnockback = entityDefender.transform.position - transform.position;
        Vector2 forceKnockback = directionKnockback.normalized * currentWeapon.Knockback * entityDefender.Data.KnockbackMultiplier;

        if (forceKnockback != Vector2.zero) entityDefender.rb.DOMove((Vector2)entityDefender.transform.position + forceKnockback, .2f);
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
            CanAttack = true;
        }
    }
}
