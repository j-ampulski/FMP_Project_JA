using UnityEngine;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] firePoints;

    public float bulletSpeed = 20f;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;

    public AudioSource bulletSoundMain;

    void Update()
    {
        // Keep gun aligned with player
        transform.localRotation = Quaternion.identity;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            bulletSoundMain.Play();
        }
    }

    void Shoot()
    {
        foreach (Transform fp in firePoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, fp.position, fp.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = fp.right * bulletSpeed;
        }
    }
}