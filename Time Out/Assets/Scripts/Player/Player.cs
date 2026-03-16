using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement and Settings")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [Header("Inputs")]
    [SerializeField] private float moveInputX;
    [SerializeField] private float moveInputY;
    [SerializeField] private Vector2 mousePos;

    void Update()
    {
        moveInputX = Input.GetAxis("Horizontal") * Time.deltaTime;
        moveInputY = Input.GetAxis("Vertical") * Time.deltaTime;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Move();

        MouseLook();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveInputX * speed, moveInputY * speed);
    }

    void MouseLook()
    {
        Vector2 direction = mousePos - rb.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}