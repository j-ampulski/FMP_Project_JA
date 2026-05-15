using UnityEngine;

public class PauseScene : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject UIDisable;

    private bool isopen = false;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            if (isopen)
            {
                PauseMenu.SetActive(false);
                UIDisable.SetActive(true);
                isopen = false;
                Time.timeScale = 1f; // stops player from moving
            }
            else 
            {
                PauseMenu.SetActive(true);
                UIDisable.SetActive(false);
                isopen = true;
                Time.timeScale = 0f; // stops player from moving
            }
        }
    }
}
