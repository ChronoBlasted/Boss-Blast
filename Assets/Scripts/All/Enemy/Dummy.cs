using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Entity
{
    public override void Die()
    {
        base.Die();
    }

    public override bool TakeDamage(float damageTaken)
    {
        return base.TakeDamage(damageTaken);
    }
}
