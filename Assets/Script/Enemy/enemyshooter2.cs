using UnityEngine;

public class EnemyShooter2 : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("Shoot")]
    [SerializeField] private float fireRate = 1f;

    [Header("Spread")]
    [SerializeField] private float spreadAngle = 25f;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    private void Shoot()
    {
        ShootBullet(-spreadAngle);
        ShootBullet(0);
        ShootBullet(spreadAngle);
    }

    private void ShootBullet(float angle)
    {
        GameObject bullet = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity);

        Vector2 direction =
            Quaternion.Euler(0, 0, angle) * Vector2.down;

        if (bullet.TryGetComponent(out EnemyProjectile2 projectile))
        {
            projectile.SetDirection(direction);
        }
    }
}