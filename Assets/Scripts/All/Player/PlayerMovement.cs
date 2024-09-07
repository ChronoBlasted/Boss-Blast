using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] EntityData Data;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] InputActionReference movement, dash, mousePos;

    Vector2 movementInput, mousePosition;
    Vector3 directionToLookAt;

    bool isDashing = false;

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>();
        mousePosition = mousePos.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(movementInput.x * Data.Speed[0], movementInput.y * Data.Speed[0]);
        }
    }

    void LateUpdate()
    {
        directionToLookAt = cam.ScreenToWorldPoint(mousePosition);
        directionToLookAt.z = 0f;

        transform.up = directionToLookAt - transform.position;
        if (transform.up == Vector3.down)
        {
            var newRotation = Quaternion.Euler(0f, 0f, 180f);
            transform.rotation = newRotation;
        }
    }

    async void Dash(InputAction.CallbackContext context)
    {
        if (isDashing || movementInput == Vector2.zero) return;

        isDashing = true;

        rb.velocity = new Vector2(movementInput.x * Data.DashSpeed[0], movementInput.y * Data.DashSpeed[0]);

        await Task.Delay(100);

        isDashing = false;
    }

    void OnEnable()
    {
        dash.action.performed += Dash;
    }

    void OnDisable()
    {
        dash.action.performed -= Dash;
    }
}
