using DG.Tweening;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] int layerToAttack = 20;
    [SerializeField] AttackSystem attackSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerToAttack)
        {
            var target = collision.gameObject.GetComponent<Entity>();

            attackSystem.Attack(target);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
