using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float Health = 100f;
    public float MaxHealth = 100f;
    public float HealthPerSecond = .1f;
    public ParticleSystem HitFX;

    GameObject _floatingTextGO;

    public virtual bool TakeDamage(float damageTaken)
    {
        Health -= damageTaken;

        HitFX.Play();

        _floatingTextGO = PoolManager.Instance.gameobjectPoolDictionary["FloatingText"].Get();
        _floatingTextGO.transform.SetParent(transform);
        var _floatingText = _floatingTextGO.GetComponent<FloatingText>();
        _floatingText.InitSmall(damageTaken);

        if (Health <= 0)
        {
            Health = 0;
            Die();
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void Die()
    {

    }
}
