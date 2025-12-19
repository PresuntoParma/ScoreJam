using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement Config")]
    [SerializeField] private float speed;
    private float moveX;
    private float moveY;

    private Vector2 move;

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        MoveInput();
    }

    private void MoveInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        move = new Vector2 (moveX, moveY);
        move = move.normalized;
    }

    private void Move()
    {
        rb.linearVelocity = move * speed;
    }
}