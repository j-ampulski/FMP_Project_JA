using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; // How long the bullet will last
    [SerializeField]
    private int damage = 2; // How much damage the bullet will do 

    void Start()
    {
        Destroy(gameObject, lifeTime);   // Destroys the bullet once its lifetime is over
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>(); 
        BossHealth Boss = collision.GetComponent<BossHealth>();

        if (enemy != null) // checks if it hits enemy then take damage and delete bullet
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); 
        }

        if (Boss != null) // checks if it hits Boss then take damage and delete bullet
        {
            Boss.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }
}