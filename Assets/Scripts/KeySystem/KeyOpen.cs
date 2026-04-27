using TMPro;
using UnityEngine;

public class KeyInteractTrigger : MonoBehaviour
{
    [Header("UI Prompt")]
    public TextMeshProUGUI keyPromptUI;

    [Header("Tutorial Key")]
    public TextMeshProUGUI KeyTut;

    private bool isPlayerNearby = false;

    [SerializeField]
    [Header("Doors to open")]
    private GameObject[] DoorsToOpen;
    void Start()
    {
        if (keyPromptUI != null)
            keyPromptUI.enabled = false;
    }

    void Update()
    {
        if (!isPlayerNearby) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupKey();
            OpenDoors();
            KeyTut.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;

            if (keyPromptUI != null)
                keyPromptUI.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (keyPromptUI != null)
                keyPromptUI.enabled = false;
        }
    }

    void PickupKey()
    {
        if (keyPromptUI != null)
            keyPromptUI.enabled = false;

        gameObject.SetActive(false);
    }

    void OpenDoors()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
    }
}