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
       
        transform.localRotation = Quaternion.identity; // makes sure the gun is aligned with the player

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // checking if the mouse button is down
        {
            Shoot();              
            nextFireTime = Time.time + fireRate; //Resets the next fire time
            bulletSoundMain.Play();  // plays the audio
        }
    }

    void Shoot()  
    {
        foreach (Transform fp in firePoints)  // Since fire points is a array 
        {
            GameObject bullet = Instantiate(bulletPrefab, fp.position, fp.rotation); // Instantiates the bullet where the player is looking

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // gets the bullets rigidbody
            rb.linearVelocity = fp.right * bulletSpeed; // makes the bullet travel to what you set it to 
        }
    }
}