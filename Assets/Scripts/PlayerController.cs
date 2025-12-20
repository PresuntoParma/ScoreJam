using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private ScoreManager scoreManager;

    [Header("Movement Config")]
    [SerializeField] private float speed;
    private float moveX;
    private float moveY;
    private float baseSpeed;
    private bool slowed;

    [Header("Kick Config")]
    [SerializeField] private BoxCollider2D kickCollider;
    [SerializeField] private float kickWindow;
    [SerializeField] private float kickCooldown;
    private bool canKick;
    

    private Vector2 move;

    private void Start()
    {
        baseSpeed = speed;
        canKick = true;
    }

    private void Update()
    {
        GetInput();
        Flip();
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

    private void Flip()
    {
        if (rb.linearVelocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rb.linearVelocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
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
        anim.SetTrigger("pKick");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && slowed == false)
        {
            StartCoroutine(Slow());
            scoreManager.LoseCombo();
        }
    }

    private IEnumerator Slow()
    {
        anim.SetTrigger("pFall");
        slowed = true;
        speed -= 3;
        yield return new WaitForSeconds(1);
        speed = baseSpeed;
        slowed = false;
    }
}