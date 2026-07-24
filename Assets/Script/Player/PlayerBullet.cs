using UnityEngine;
 
public class PlayerBullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;
 
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
 
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
 