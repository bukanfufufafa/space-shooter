using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private int damage = 1;

    private Vector2 direction;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Hitung arah ke player hanya sekali
            direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            // Jika player tidak ada, bergerak ke kiri
            direction = Vector2.left;
        }
    }

    private void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        // Hancurkan jika keluar layar
        if (transform.position.x < -12f ||
            transform.position.x > 12f ||
            transform.position.y < -7f ||
            transform.position.y > 7f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
                player.TakeDamage(damage);

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