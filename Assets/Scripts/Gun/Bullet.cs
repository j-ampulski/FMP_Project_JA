using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    [SerializeField]
    private int damage = 2;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // bullet disappears on hit
        }
    }
}