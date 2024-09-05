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
            rb.velocity = new Vector2(movementInput.x * Data.Speed, movementInput.y * Data.Speed);
        }
    }

    void LateUpdate()
    {
        directionToLookAt = cam.ScreenToWorldPoint(mousePosition);
        directionToLookAt.z = 0f;

        transform.up = directionToLookAt - transform.position;
    }

    async void Dash(InputAction.CallbackContext context)
    {
        if (isDashing || movementInput == Vector2.zero) return;

        isDashing = true;

        rb.velocity = new Vector2(movementInput.x * Data.DashSpeed, movementInput.y * Data.DashSpeed);

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
