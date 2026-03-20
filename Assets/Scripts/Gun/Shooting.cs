using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 20f;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;

    void Update()
    {
        // Keep gun aligned with player (since it's a child)
        transform.localRotation = Quaternion.identity;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed;
    }
}