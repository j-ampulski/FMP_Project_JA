using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] 
    private GameObject endScreen;
    [SerializeField] 
    private TextMeshProUGUI ScoreText;

    private void Start()
    {
        endScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowEndScreen();
        }
    }

    void ShowEndScreen()
    {
        endScreen.SetActive(true);

        if (CurrencyManager.Instance != null)
        {
            ScoreText.text = "Score: " + CurrencyManager.Instance.money;
        }
        else
        {
            ScoreText.text = "Score: 0";
        }

        Time.timeScale = 0f;
    }

    public void Respawn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}