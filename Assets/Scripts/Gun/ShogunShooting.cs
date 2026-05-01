using UnityEngine;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float bulletSpeed = 20f;

    [SerializeField]
    private float fireRate = 0.2f;

    [SerializeField]
    private float nextFireTime = 0f;

    [SerializeField]
    private int pelletCount = 3;

    [SerializeField]
    private float spreadAngle = 15f;

    void Update()
    {
      
        transform.localRotation = Quaternion.identity; // Keep gun aligned with player

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Checks if the mouse button is down and also if the fire time is done
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float step = spreadAngle * 2 / (pelletCount - 1); // makes the spread angle divided by the pellet count to see how spread each bullet should be

        for (int i = 0; i < pelletCount; i++) 
        {
            float angle = -spreadAngle + (step * i);
            Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, angle);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = rotation * Vector2.right * bulletSpeed;
        }
    }
}