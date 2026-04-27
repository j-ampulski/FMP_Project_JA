using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class RoomDoorManager : MonoBehaviour
{
    [Header("Doors")]
    [SerializeField] 
    private GameObject door1;
    [SerializeField] 
    private GameObject door2;
    [SerializeField]
    private GameObject door3;
    [SerializeField]
    private Slider BossHealthBar;

    private bool doorsLocked = false;

    public void LockDoors()
    {
        if (doorsLocked) return;

        door1.SetActive(true);
        door2.SetActive(true);
        door3.SetActive(true);
        BossHealthBar.gameObject.SetActive(true);
        doorsLocked = true;
    }

    public void OpenDoors()
    {
        door1.SetActive(false);
        door2.SetActive(false);
        door3.SetActive(false);
        BossHealthBar.gameObject.SetActive(false);
    }
}