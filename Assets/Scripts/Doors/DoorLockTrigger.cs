using UnityEngine;

public class DoorLockTrigger : MonoBehaviour
{
    [SerializeField] private RoomDoorManager doorManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorManager.LockDoors();
        }
    }
}