using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{

    public override void Die()
    {
        base.Die();

        GameManager.Instance.ReloadScene();
    }

}
