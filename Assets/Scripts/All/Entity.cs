using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityData Data;
    public ParticleSystem HitFX;
    public Rigidbody2D rb;

    GameObject _floatingTextGO;

    bool canTakeDamage = true;
    float health;

    public Action<float> OnTakeDamage;

    Coroutine invincibilityCor;

    public bool CanTakeDamage { get => canTakeDamage; }

    private void Awake()
    {
        SetHealth(Data.MaxHealth);
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    public void ForceInvincibility(bool isInvincible)
    {
        if (invincibilityCor != null)
        {
            StopCoroutine(invincibilityCor);
            invincibilityCor = null;
        }

        canTakeDamage = !isInvincible;
    }

    public virtual bool TakeDamage(float damageTaken)
    {
        if (invincibilityCor != null)
        {
            StopCoroutine(invincibilityCor);
            invincibilityCor = null;
        }
        invincibilityCor = StartCoroutine(InvincibilityCoroutine());

        health -= damageTaken;

        HitFX.Play();

        _floatingTextGO = PoolManager.Instance.gameobjectPoolDictionary["FloatingText"].Get();
        _floatingTextGO.transform.position = transform.position;
        var _floatingText = _floatingTextGO.GetComponent<FloatingText>();

        _floatingText.InitSmall(damageTaken, Data.ColorEntity);

        if (health <= 0)
        {
            health = 0;
            Die();
            OnTakeDamage?.Invoke(health);
            return true;
        }
        else if (health >= Data.MaxHealth)
        {
            health = Data.MaxHealth;
            OnTakeDamage?.Invoke(health);
            return false;
        }
        else
        {
            OnTakeDamage?.Invoke(health);
            return false;
        }
    }

    public virtual void Die()
    {

    }

    IEnumerator InvincibilityCoroutine()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(Data.InvicibilityTimeStamp);
        canTakeDamage = true;
    }
}
