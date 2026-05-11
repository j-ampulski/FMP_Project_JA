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

    private void Start()  // making sure the end screen isnt accidently on
    {
        endScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)   // checking if the collision was the player and if it was then show end screen
    {
        if (other.CompareTag("Player"))
        {
            ShowEndScreen();
        }
    }

    void ShowEndScreen()  
    {
        endScreen.SetActive(true); // Turning on the endscreen so the player can see it

        if (CurrencyManager.Instance != null)  // Making sure that i have a score system
        {
            ScoreText.text = "Score: " + CurrencyManager.Instance.money; // Showing what score the player has accumulated
        }
        else
        {
            ScoreText.text = "Score: 0"; // Keeping the score as 0 if no currecny manager script
        }

        Time.timeScale = 0f;  // Also freezes the  game so the player can do anything but only move his mouse
    }

    public void Respawn()
    {
        Time.timeScale = 1f;  // Un freezes the game if the player has respawned
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Where to respawn the player
    }
}