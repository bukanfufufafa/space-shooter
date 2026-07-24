using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("Shoot Setting")]
    [SerializeField] private float fireRate = 1f;
    
    private float fireTimer;

    [SerializeField] private bool inCam = false;
    [SerializeField] private float leftOffSide;
    [SerializeField] private float rightOffSide;
    [SerializeField] private Vector2 offside;
    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
           
            if (gameObject.transform.position.x >= leftOffSide && gameObject.transform.position.x <= rightOffSide)
            {
                Shoot();
                fireTimer = 0f;
            }
            
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }

    
}