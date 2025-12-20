using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    private int direction;
    public float minSpeed;
    public float maxSpeed;
    private float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed + 0.1f);
        if (transform.position.x > 0)
        {
            direction = -1;
            sr.flipX = true;
        }
        else
        {
            direction = 1;
            sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
