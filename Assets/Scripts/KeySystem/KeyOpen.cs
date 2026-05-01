using TMPro;
using UnityEngine;

public class KeyInteractTrigger : MonoBehaviour
{
    [Header("UI Prompt")]
    public TextMeshProUGUI keyPromptUI;

    [Header("Tutorial Key")]
    public GameObject KeyTut;

    private bool isPlayerNearby = false;

    [SerializeField]
    [Header("Doors to open")]
    private GameObject[] DoorsToOpen;

    public bool IsKeyOpen = false;

    [SerializeField]
    [Header("Tutorial Key")]
    private GameObject BossTut;


    void Start()
    {
        if (keyPromptUI != null)                
            keyPromptUI.enabled = false;
    }

    void Update()
    {
        if (!isPlayerNearby) return;     // checking is player is in range of the key

        if (Input.GetKeyDown(KeyCode.E)) // if player is in range and the key E is pressed then it opens doors also turns off the tutorial for the key
        {
            PickupKey();
            OpenDoors();
            KeyTut.SetActive(false);
            BossTut.SetActive(true);

            IsKeyOpen = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    { 
        if (other.CompareTag("Player"))  // checking if the player is the one in range
        {
            isPlayerNearby = true;       // if player is in range then 

            if (keyPromptUI != null)
                keyPromptUI.enabled = true; // show the Press E to pickup 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // checking if the player is the one in range
        {
            isPlayerNearby = false; // if player is not in range then 

            if (keyPromptUI != null)
                keyPromptUI.enabled = false;  // make sure the Press E UI is not on
        }
    }

    void PickupKey()
    {
        if (keyPromptUI != null)
            keyPromptUI.enabled = false;

        gameObject.SetActive(false);   // gets rid of the key
    }

    void OpenDoors()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");  // Looks for any thing tagged with the door tag

        foreach (GameObject door in doors)  // since its an array it does it for each object
        {
            door.SetActive(false);  // Disables the doors
        }
    }
}