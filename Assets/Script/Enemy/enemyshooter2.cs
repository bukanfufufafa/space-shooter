using UnityEngine;

public class EnemyShooter2 : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("Shoot Setting")]
    [SerializeField] private float fireRate = 1f;

    [Header("Triple Shot")]
    [SerializeField] private float bulletSpacing = 0.5f;

    [Header("Shoot Area")]
    [SerializeField] private float leftOffSide;
    [SerializeField] private float rightOffSide;

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
        Debug.Log("Shoot!");

        Instantiate(projectilePrefab,
            firePoint.position + Vector3.left * bulletSpacing,
            Quaternion.identity);

        Instantiate(projectilePrefab,
            firePoint.position,
            Quaternion.identity);

        Instantiate(projectilePrefab,
            firePoint.position + Vector3.right * bulletSpacing,
            Quaternion.identity);
    }
}