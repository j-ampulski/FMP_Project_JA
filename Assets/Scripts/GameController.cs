using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private GameObject player;

    public static Action<GameObject> OnPlayerSpawned;

    private void ResetScene() 
    {
        Invoke("ResetSceneDelay", 2f);
    }

    private void ResetSceneDelay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Awake()
    {
        player = Instantiate(playerPrefab);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Start()
    {
        OnPlayerSpawned?.Invoke(player);
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDie += ResetScene;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDie -= ResetScene;
    }

}
