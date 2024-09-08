using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityData Data;
    public ParticleSystem HitFX;
    public GameObject HitFxCross1;
    public GameObject HitFxCross2;
    public Rigidbody2D rb;

    public int Phase = 0;
    public int Prestige = 0;

    GameObject _floatingTextGO;

    bool canTakeDamage = true;
    float health;

    public Action<float> OnTakeDamage;

    Coroutine invincibilityCor;

    public bool CanTakeDamage { get => canTakeDamage; }

    private void Awake()
    {
        SetHealth(Data.MaxHealth[Phase] + Data.MaxHealthPerPrestige[Prestige]);
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

    public virtual bool TakeDamage(float damageTaken, bool isCrit)
    {
        if (invincibilityCor != null)
        {
            StopCoroutine(invincibilityCor);
            invincibilityCor = null;
        }
        invincibilityCor = StartCoroutine(InvincibilityCoroutine());

        health -= damageTaken;

        if (isCrit)
        {
            HitFxCross1.SetActive(true);
            HitFxCross2.SetActive(true);
        }
        else
        {
            HitFxCross1.SetActive(false);
            HitFxCross2.SetActive(false);
        }

        HitFX.Play();

        _floatingTextGO = PoolManager.Instance.gameobjectPoolDictionary["FloatingText"].Get();
        _floatingTextGO.transform.position = transform.position;
        var _floatingText = _floatingTextGO.GetComponent<FloatingText>();

        _floatingText.InitSmall(damageTaken, Data.ColorEntity);

        float MaxHealth = Data.MaxHealth[Phase] + Data.MaxHealthPerPrestige[Prestige];

        if (health <= 0)
        {
            health = 0;
            Die();
            OnTakeDamage?.Invoke(health);
            return true;
        }
        else if (health >= MaxHealth)
        {
            health = Data.MaxHealth[Phase];
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
        yield return new WaitForSeconds(Data.InvicibilityTimeStamp[Phase]);
        canTakeDamage = true;
    }
}
