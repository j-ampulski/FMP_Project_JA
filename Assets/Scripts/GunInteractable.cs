using UnityEngine;
using TMPro;
using System.Collections;
public class Interactable2D : MonoBehaviour
{
    [Header("UI Prompt")]
    public GameObject promptUI;

    [Header("Item to enable")]
    public string itemNameToEnable = "Gun";

    [Header("Tutorial text to disable")]
    public GameObject TutText;

    private bool playerInRange = false;
    private GameObject playerGO;

    [Header("Lights To Disable")]
    public GameObject GunLighting;

    [SerializeField]
    [Header("All guns Together")]
    private GameObject GunsTogether;

    [SerializeField]
    [Header("Key tutorial text")]
    private GameObject KeyTut;

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }


    void Update()
    {
        if (!playerInRange) return; // checks if the player is in range of the guns

        if (Input.GetKeyDown(KeyCode.E)) // checks if the user presses the letter E on their keyboard
        {
            Interact();                            
            TutText.SetActive(false);
            GunLighting.active = false;
            GunsTogether.active = false;
            KeyTut.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)   
    {
        if (other.CompareTag("Player"))  // checks if the player is colliding with the guns
        {
            playerGO = other.gameObject; 
            playerInRange = true;             // Checks if the player is in range 

            if (promptUI != null)
                promptUI.SetActive(true);           // If player isnt in range then keep the Prompt text popped up

            TutText.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))   // checks if the player is colliding with the guns
        {
            playerInRange = false;  // Checks if the player is not in range

            if (promptUI != null)
                promptUI.SetActive(false); // if the player is not in range then hide the prompt text

            TutText.SetActive(true);
        }
    }

    void Interact()
    {
        if (playerGO == null) // checks if the player exists
        {
            return;
        }

        Transform foundItem = null;

        foreach (Transform t in playerGO.GetComponentsInChildren<Transform>(true)) // Gets the players children so the guns
        {
            if (t.name == itemNameToEnable)  // checks if the name of the gun matches the child
            {
                foundItem = t;
                break;
            }
        }

        if (foundItem != null)   
        {
            foundItem.gameObject.SetActive(true);          // Turns the childs object on so guns appear
        }
        else
        {
            Debug.LogWarning($"no item found");
        }

        if (promptUI != null)
            promptUI.SetActive(false);

        
        gameObject.SetActive(false);  // Gets rid of the main object

    }

}