using UnityEngine;

public class RoomDoorManager : MonoBehaviour
{
    [Header("Doors")]
    [SerializeField] 
    private GameObject door1;
    [SerializeField] 
    private GameObject door2;
    [SerializeField] 
    private GameObject door3;

    private bool doorsLocked = false;

    public void LockDoors()
    {
        if (doorsLocked) return;

        door1.SetActive(true);
        door2.SetActive(true);
        door3.SetActive(true);

        doorsLocked = true;
    }

    public void OpenDoors()
    {
        door1.SetActive(false);
        door2.SetActive(false);
        door3.SetActive(false);
    }
}