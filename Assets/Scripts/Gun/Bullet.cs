using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            // destroys enemy
            Destroy(collision.gameObject);
            //Destroysthe bullet
            Destroy(gameObject);
        }
    }
}