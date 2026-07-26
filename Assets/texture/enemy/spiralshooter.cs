using UnityEngine;

public class EnemySpiralShooter : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("Shoot")]
    [SerializeField] private float fireRate = 0.08f;
    [SerializeField] private float bulletSpeed = 6f;

    [Header("Spiral")]
    [SerializeField] private float rotateSpeed = 180f; // derajat/detik

    private float fireTimer;
    private float currentAngle;

    private void Update()
    {
        currentAngle += rotateSpeed * Time.deltaTime;

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity);

        Vector2 dir = new Vector2(
            Mathf.Cos(currentAngle * Mathf.Deg2Rad),
            Mathf.Sin(currentAngle * Mathf.Deg2Rad));

        if (bullet.TryGetComponent(out BulletMove move))
        {
            move.SetDirection(dir.normalized, bulletSpeed);
        }
    }
}