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
    private bool isDead = false;    // all variables

    void Awake()   
    {
        currentHealth = health;
        maxHealth = health;
    }

    void Update()
    {
        if (isDead || currentHealth >= maxHealth) return; // Checks if the player is dead OR if the players health is currently more or equal to the players max health

        timeSinceLastDamage += Time.deltaTime;  // adds time since last damage

        if (timeSinceLastDamage >= regenDelay) // checks if time since less damage is more or equal to regen delay
        {
            regenTimer += Time.deltaTime;  

            if (regenTimer >= regenInterval)  // if regen timer is more than regen interval then regen health
            {
                regenTimer = 0f;
                Regenerate();
            }
        }
    }

    void Regenerate() 
    {
        int regenAmount = Mathf.Max(1, Mathf.RoundToInt(maxHealth * regenPercent)); // regens percentage of health that its set to
        currentHealth = Mathf.Min(currentHealth + regenAmount, maxHealth);  // makes sure that current health is set to what it regened
        OnPlayerTakeDamage?.Invoke(currentHealth);
    }

    public void TakeDamage(int damageAmount)  
    {
        currentHealth -= damageAmount;  // changes the lpayers health by damage taken
        timeSinceLastDamage = 0f;   // resets timer since last damage
        regenTimer = 0f;        // resets regen timer   

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