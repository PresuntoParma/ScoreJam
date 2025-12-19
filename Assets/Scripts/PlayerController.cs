using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement Config")]
    [SerializeField] private float speed;
    private float moveX;
    private float moveY;

    [Header("Kick Config")]
    [SerializeField] private BoxCollider2D kickCollider;
    [SerializeField] private float kickWindow;
    [SerializeField] private float kickCooldown;
    private bool canKick;
    

    private Vector2 move;

    private void Start()
    {
        canKick = true;
    }

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
        KickInput();
    }

    private void MoveInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        move = new Vector2 (moveX, moveY);
        move = move.normalized;
    }

    private void KickInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canKick && true)
        {
            StartCoroutine(Kick());
        }
    }

    private void Move()
    {
        rb.linearVelocity = move * speed;
    }

    private IEnumerator Kick()
    {
        print("kick começou");
        kickCollider.enabled = true;
        yield return new WaitForSeconds(kickWindow);
        kickCollider.enabled = false;
        print("kick terminou");
        StartCoroutine(KickCooldown());

    }

    private IEnumerator KickCooldown()
    {
        print("começou cooldown");
        canKick = false;
        yield return new WaitForSeconds(kickCooldown);
        canKick = true;
        print("cabou cooldown");
    }
}