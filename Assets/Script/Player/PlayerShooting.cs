using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 12f;
    public float fireRate = 0.25f;
    private float fireCooldown;

    private void Update()
    {
        if (fireCooldown > 0f)
            fireCooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Z) && fireCooldown <= 0f)
        {
            fireCooldown = fireRate;

            GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            PlayerBullet bullet = bulletObj.GetComponent<PlayerBullet>();
            if (bullet != null)
                bullet.speed = bulletSpeed;
        }
    }
}