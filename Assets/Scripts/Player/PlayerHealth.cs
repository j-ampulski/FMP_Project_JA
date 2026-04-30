using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private Animator animator;

    [Header("Regeneration")]
    [SerializeField] 
    private float regenDelay = 3f;      
    [SerializeField] 
    private float regenInterval = 1f;   
    [SerializeField] 
    private float regenPercent = 0.10f;
    [SerializeField]
    private AudioSource TakeDamageAudio;

    public int currentHealth { get; private set; }
    public int maxHealth { get; private set; }

    public static Action<int> OnPlayerTakeDamage;
    public static Action OnPlayerDie;

    private const string flashRedAnim = "FlashRed";

    private float timeSinceLastDamage = 0f;
    private float regenTimer = 0f;
    private bool isDead = false;

    void Awake()
    {
        currentHealth = health;
        maxHealth = health;
    }

    void Update()
    {
        if (isDead || currentHealth >= maxHealth) return;

        timeSinceLastDamage += Time.deltaTime;

        if (timeSinceLastDamage >= regenDelay)
        {
            regenTimer += Time.deltaTime;

            if (regenTimer >= regenInterval)
            {
                regenTimer = 0f;
                Regenerate();
            }
        }
    }

    void Regenerate()
    {
        int regenAmount = Mathf.Max(1, Mathf.RoundToInt(maxHealth * regenPercent));
        currentHealth = Mathf.Min(currentHealth + regenAmount, maxHealth);
        OnPlayerTakeDamage?.Invoke(currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        timeSinceLastDamage = 0f;  
        regenTimer = 0f;           

        OnPlayerTakeDamage?.Invoke(currentHealth);
        animator.SetTrigger(flashRedAnim);
        TakeDamageAudio.Play();

        if (currentHealth <= 0)
        {
            isDead = true;
            OnPlayerDie?.Invoke();
            gameObject.SetActive(false);
        }
    }
}