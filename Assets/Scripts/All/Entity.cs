using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityData Data;

    public Collider2D HitCollider;
    public ParticleSystem HitFX;

    GameObject _floatingTextGO;

    public virtual bool TakeDamage(float damageTaken)
    {
        StartCoroutine(InvicibilityCoroutine());

        Data.Health -= damageTaken;

        HitFX.Play();

        _floatingTextGO = PoolManager.Instance.gameobjectPoolDictionary["FloatingText"].Get();
        _floatingTextGO.transform.SetParent(transform);
        var _floatingText = _floatingTextGO.GetComponent<FloatingText>();
        _floatingText.InitSmall(damageTaken);

        if (Data.Health <= 0)
        {
            Data.Health = 0;
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

    IEnumerator InvicibilityCoroutine()
    {
        HitCollider.enabled = false;
        yield return new WaitForSeconds(Data.InvicibilityTimeStamp);
        HitCollider.enabled = true;
    }
}
