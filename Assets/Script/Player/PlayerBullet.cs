using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;

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
            Destroy(gameObject);
        }
    }
}