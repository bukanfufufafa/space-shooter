using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 12f;
    public float fireRate = 0.25f;
    private float fireCooldown;

    [Header("Passive: Tri Shot")]
    public bool tripleShotEnabled = false;
    public float spreadAngle = 15f;     

    private void Update()
    {
        if (fireCooldown > 0f)
            fireCooldown -= Time.unscaledDeltaTime;

        if (Input.GetKey(KeyCode.Z) && fireCooldown <= 0f)
        {
            fireCooldown = fireRate;

            if (tripleShotEnabled)
                FireTripleShot();
            else
                FireSingleShot(Quaternion.identity);
        }
    }

    private void FireSingleShot(Quaternion rotation)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, rotation);
        PlayerBullet bullet = bulletObj.GetComponent<PlayerBullet>();
        if (bullet != null)
        {
            bullet.speed = bulletSpeed;
            bullet.transform.up = rotation * Vector3.up;
        }
    }

    private void FireTripleShot()
    {
        FireSingleShot(Quaternion.identity);                           // lurus tengah
        FireSingleShot(Quaternion.Euler(0f, 0f, spreadAngle));          // miring kiri
        FireSingleShot(Quaternion.Euler(0f, 0f, -spreadAngle));         // miring kanan
    }
}