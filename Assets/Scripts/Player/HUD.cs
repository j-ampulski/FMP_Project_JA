using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
public class HUD : MonoBehaviour
{
    [SerializeField] private Slider healthbar;
    private int maxHealth;

    private void SetupHealthbar(GameObject player)
    {
        healthbar.value = healthbar.maxValue;
        maxHealth = player.GetComponent<PlayerHealth>().maxHealth;
    }

    private void UpdateHealthbar(int currentHealth)
    {
        healthbar.value = (float)currentHealth / maxHealth;
        healthbar.value = Mathf.Clamp01(healthbar.value);
    }

    private void OnEnable()
    {
        GameController.OnPlayerSpawned += SetupHealthbar;
        PlayerHealth.OnPlayerTakeDamage += UpdateHealthbar;
    }

    private void OnDisable()
    {
        GameController.OnPlayerSpawned -= SetupHealthbar;
        PlayerHealth.OnPlayerTakeDamage -= UpdateHealthbar;
    }
}
