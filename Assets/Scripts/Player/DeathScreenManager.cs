using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] 
    private GameObject deathScreen;
    [SerializeField] 
    private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDie += ShowDeathScreen;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDie -= ShowDeathScreen;
    }

    void ShowDeathScreen()
    {
        deathScreen.SetActive(true); 

        if (CurrencyManager.Instance != null)
        {
            scoreText.text = "Score: " + CurrencyManager.Instance.money;
        }

        Time.timeScale = 0f;
    }

    public void Respawn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}