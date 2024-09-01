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
        Debug.Log("Dummy take's : " + damageTaken + " damaged !");

        TimeManager.Instance.DoLagTime();
        return base.TakeDamage(damageTaken);
    }
}
