using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;
    public float damage = 5f; 

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSecondsRealtime(lifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.unscaledDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemystat enemyStat = other.GetComponent<enemystat>();
            if (enemyStat != null)
                enemyStat.takedamage(damage);

            if (PlayerPowerController.Instance != null)
                PlayerPowerController.Instance.AddPowerFromDamage(damage);

            Destroy(gameObject);
        }
    }
}