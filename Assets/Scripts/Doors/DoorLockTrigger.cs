using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class DoorLockTrigger : MonoBehaviour
{
    [SerializeField] 
    private RoomDoorManager doorManager;

    [SerializeField]
    private AudioSource DoorClosing;

    private bool IsAudioPlayed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorManager.LockDoors();

            if (!IsAudioPlayed) 
            {
                DoorClosing.Play();
                IsAudioPlayed = true; 
            }
        }
    }
}