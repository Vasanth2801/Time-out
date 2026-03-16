using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement and Settings")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Inputs")]
    [SerializeField] private float moveInputX;
    [SerializeField] private float moveInputY;

    void Update()
    {
        moveInputX = Input.GetAxis("Horizontal") * Time.deltaTime;
        moveInputY = Input.GetAxis("Vertical") * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveInputX * speed, moveInputY * speed);
    }
}