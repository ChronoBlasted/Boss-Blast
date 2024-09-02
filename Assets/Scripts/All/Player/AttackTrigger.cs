using DG.Tweening;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] int layerToAttack = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerToAttack)
        {
            var target = collision.gameObject.GetComponent<Entity>();

            target.TakeDamage(10);

            target.transform.DOMove(target.transform.position + (target.transform.position - PlayerManager.Instance.transform.position), .5f).SetUpdate(UpdateType.Fixed);

            CameraManager.Instance.ShakeCamera(2, .075f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
