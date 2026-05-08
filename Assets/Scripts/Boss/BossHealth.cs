using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class BossHealth : MonoBehaviour
{
    [Header("Set The Boss Health")]
    [SerializeField] 
    private int MaxBossHealth = 100;

    [Header("Wave 1 Zombies")]
    [SerializeField] 
    private GameObject[] Wave1;

    [Header("Wave 2 Zombies")]
    [SerializeField] 
    private GameObject[] Wave2;

    [Header("Wave 3 Zombies")]
    [SerializeField] 
    private GameObject[] Wave3;

    [SerializeField] 
    private RoomDoorManager doorManager;

    [SerializeField]
    private Slider bossHealthSlider;

    [SerializeField]
    private GameObject Bosstut;


    public int amountWorth = 1;

    public int currentBossHealth { get; private set; }

    
    private bool wave1Triggered = false;
    private bool wave2Triggered = false;
    private bool wave3Triggered = false;

    void Start()
    {
        currentBossHealth = MaxBossHealth;  // setting the bosses health

        bossHealthSlider.maxValue = MaxBossHealth;
        bossHealthSlider.value = currentBossHealth;

        SetWaveActive(Wave1, false);
        SetWaveActive(Wave2, false);
        SetWaveActive(Wave3, false);
    }

    public void TakeDamage(int damage)
    {
        currentBossHealth -= damage;  // adjustings bosses health to damage
        currentBossHealth = Mathf.Clamp(currentBossHealth, 0, MaxBossHealth); 
        bossHealthSlider.value = currentBossHealth; // setting the bosses UI health bar to its health

        float healthPercent = (float)currentBossHealth / MaxBossHealth * 100f; // finding the bosses health percentage

        
        if (!wave1Triggered && healthPercent <= 75f)   // Triggering Wave 1 below 75%
        {
            SetWaveActive(Wave1, true);
            wave1Triggered = true;
        }

        
        if (!wave2Triggered && healthPercent <= 40f) // Triggering wave 2 below 40%
        {
            SetWaveActive(Wave2, true);
            wave2Triggered = true;
        }

       
        if (!wave3Triggered && healthPercent <= 20f) // Triggering wave 3 below 20%
        {
            SetWaveActive(Wave3, true);
            wave3Triggered = true;
        }

        
        if (currentBossHealth <= 0) // Bosses Death
        {
            CurrencyManager.Instance.AddMoney(amountWorth); // Giving the player the score its set to
            
            Bosstut.SetActive(false);        // getting rid of the boss UI

            if (doorManager != null)
                doorManager.OpenDoors();

            Destroy(gameObject);  // Getting rid of the Boss
        }
    }

    void SetWaveActive(GameObject[] wave, bool state) // Checking What wave got spawned
    {
        foreach (GameObject zombie in wave) // since its a array it has to go through each object in it then enable it
        {
            if (zombie != null)
                zombie.SetActive(state);
        }
    }
}