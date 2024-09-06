using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityData Data;
    public ParticleSystem HitFX;

    GameObject _floatingTextGO;

    bool canTakeDamage = true;
    float health;


    private void Awake()
    {
        health = Data.MaxHealth;
    }

    public virtual bool TakeDamage(float damageTaken)
    {
        if (canTakeDamage == false) return false;

        StartCoroutine(InvicibilityCoroutine());

        health -= damageTaken;

        HitFX.Play();

        _floatingTextGO = PoolManager.Instance.gameobjectPoolDictionary["FloatingText"].Get();
        _floatingTextGO.transform.position = transform.position;
        var _floatingText = _floatingTextGO.GetComponent<FloatingText>();
        _floatingText.InitSmall(damageTaken);

        if (health <= 0)
        {
            health = 0;
            Die();
            return true;
        }
        else if (health >= Data.MaxHealth)
        {
            health = Data.MaxHealth;
            return false;
        }
        else
        {
            return false;
        }
    }

    public virtual void Die()
    {

    }

    IEnumerator InvicibilityCoroutine()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(Data.InvicibilityTimeStamp);
        canTakeDamage = true;
    }
}
