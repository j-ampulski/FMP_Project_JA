using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public int maxHealth;
    private int currentHealth;
    private const string flashRedAnim = "E_Flashred";

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        animator.SetTrigger(flashRedAnim);

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
