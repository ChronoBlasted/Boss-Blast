using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float Health = 100f;
    public float MaxHealth = 100f;
    public float HealthPerSecond = .1f;

    public virtual bool TakeDamage(float damageTaken)
    {
        Health -= damageTaken;

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
