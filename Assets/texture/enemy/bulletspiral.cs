using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Vector2 direction;
    private float speed;

    public void SetDirection(Vector2 dir, float moveSpeed)
    {
        direction = dir;
        speed = moveSpeed;
    }

    private void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        if (transform.position.x < -12 ||
            transform.position.x > 12 ||
            transform.position.y < -8 ||
            transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // PlayerHealth player = other.GetComponent<PlayerHealth>();
            // if (player != null)
            //     player.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // PlayerHealth player = other.GetComponent<PlayerHealth>();
            // if (player != null)
            //     player.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}