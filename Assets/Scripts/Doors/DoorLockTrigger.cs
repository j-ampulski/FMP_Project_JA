using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class DoorLockTrigger : MonoBehaviour
{
    [SerializeField] 
    private RoomDoorManager doorManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorManager.LockDoors();
        }
        
    }
}