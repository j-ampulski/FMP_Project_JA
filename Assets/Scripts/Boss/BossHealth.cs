using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("Set The Boss Health")]
    [SerializeField] private int MaxBossHealth = 100;

    [Header("Wave 1 Zombies")]
    [SerializeField] private GameObject[] Wave1;

    [Header("Wave 2 Zombies")]
    [SerializeField] private GameObject[] Wave2;

    [Header("Wave 3 Zombies")]
    [SerializeField] private GameObject[] Wave3;

    public int amountWorth = 1;

    public int currentBossHealth { get; private set; }

    
    private bool wave1Triggered = false;
    private bool wave2Triggered = false;
    private bool wave3Triggered = false;

    void Start()
    {
        currentBossHealth = MaxBossHealth;

        
        SetWaveActive(Wave1, false);
        SetWaveActive(Wave2, false);
        SetWaveActive(Wave3, false);
    }

    public void TakeDamage(int damage)
    {
        currentBossHealth -= damage;

        float healthPercent = (float)currentBossHealth / MaxBossHealth * 100f;

        // Wave 1 below 75%
        if (!wave1Triggered && healthPercent <= 75f)
        {
            SetWaveActive(Wave1, true);
            wave1Triggered = true;
        }

        // Wave 2 below 40%
        if (!wave2Triggered && healthPercent <= 40f)
        {
            SetWaveActive(Wave2, true);
            wave2Triggered = true;
        }

        // Wave 3 below 20%
        if (!wave3Triggered && healthPercent <= 20f)
        {
            SetWaveActive(Wave3, true);
            wave3Triggered = true;
        }

        // Death
        if (currentBossHealth <= 0)
        {
            CurrencyManager.Instance.AddMoney(amountWorth);
            Destroy(gameObject);
        }
    }

    void SetWaveActive(GameObject[] wave, bool state)
    {
        foreach (GameObject zombie in wave)
        {
            if (zombie != null)
                zombie.SetActive(state);
        }
    }
}