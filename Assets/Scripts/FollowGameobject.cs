using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] float offsetX = 0f, offsetY = 0f, offsetZ = 0f;
    [SerializeField] float smoothSpeed = 0.125f;

    Vector3 desiredPosition;
    Vector3 smoothedPosition;

    void LateUpdate()
    {
        desiredPosition = new Vector3(objectToFollow.position.x + offsetX, objectToFollow.position.y + offsetY, objectToFollow.position.z + offsetZ);
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
