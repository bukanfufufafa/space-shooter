using UnityEngine;

public class enemystat : MonoBehaviour
{
    public float health = 100;
    public float damage = 10;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takedamage(float playerHit)
    {
        health -= playerHit;
    }
}