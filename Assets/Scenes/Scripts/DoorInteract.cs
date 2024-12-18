using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public Transform posOpen;
    public Transform posDefault;
    public AudioSource openSound;
    public AudioSource closeSound;
    bool isOpen = false;

    public void OpenDoor()
    {
        if (isOpen == false)
        {
            transform.position = posOpen.transform.position;
            transform.rotation = posOpen.transform.rotation;
            openSound.Play();
            isOpen = true;
        }
        else
        {
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        transform.position = posDefault.transform.position;
        transform.rotation = posDefault.transform.rotation;
        closeSound.Play();
        isOpen = false;
    }
}
