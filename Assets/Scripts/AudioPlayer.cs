using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public KeyInteractTrigger IsKeyOpen_Key1;
    public KeyInteractTrigger IsKeyOpen_Key2;

    [SerializeField]
    private AudioSource DoorOpen;

    private bool hasPlayed = false;

    private void Update()
    {
        if (!hasPlayed && (IsKeyOpen_Key1.IsKeyOpen || IsKeyOpen_Key2.IsKeyOpen))
        {
            DoorOpen.Play();
            hasPlayed = true;
        }
    }
}