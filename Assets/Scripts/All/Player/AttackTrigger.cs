using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] int layerToAttack = 20;
    [SerializeField] AttackSystem attackSystem;
    [SerializeField] BoxCollider2D attackTriggerCollider;
    [SerializeField] List<Entity> enemies = new List<Entity>();

    public BoxCollider2D AttackTriggerCollider { get => attackTriggerCollider; }
    public List<Entity> Enemies { get => enemies; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerToAttack)
        {
            var target = collision.gameObject.GetComponent<Entity>();

            if (target == null) return;

            if (enemies.Contains(target) == false)
            {
                enemies.Add(target);

                attackSystem.Attack(target);
            }
        }
    }
}
