using UnityEngine;
using TMPro;
public class Interactable2D : MonoBehaviour
{
    [Header("UI Prompt")]
    public GameObject promptUI;

    [Header("Item to enable")]
    public string itemNameToEnable = "Gun";

    [Header("Tutorial text to disable")]
    public TextMeshProUGUI TutText;

    private bool playerInRange = false;
    private GameObject playerGO;

    [Header("Lights To Disable")]
    public GameObject GunLighting;

    [SerializeField]
    [Header("All guns Together")]
    private GameObject GunsTogether;

    [SerializeField]
    [Header("Key tutorial text")]
    private TextMeshProUGUI KeyTut;

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            TutText.enabled = false;
            GunLighting.active = false;
            GunsTogether.active = false;
            KeyTut.gameObject.active = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerGO = other.gameObject;
            playerInRange = true;

            if (promptUI != null)
                promptUI.SetActive(true);

            TutText.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptUI != null)
                promptUI.SetActive(false);

            TutText.enabled = true;
        }
    }

    void Interact()
    {
        if (playerGO == null)
        {
            return;
        }

        Transform foundItem = null;

        foreach (Transform t in playerGO.GetComponentsInChildren<Transform>(true))
        {
            if (t.name == itemNameToEnable)
            {
                foundItem = t;
                break;
            }
        }

        if (foundItem != null)
        {
            foundItem.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"no item found");
        }

        if (promptUI != null)
            promptUI.SetActive(false);

        // Gets rid of the main object
        gameObject.SetActive(false);

    }
}