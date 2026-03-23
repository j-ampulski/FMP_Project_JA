using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
 
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
