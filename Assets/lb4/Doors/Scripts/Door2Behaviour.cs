using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Behaviour : MonoBehaviour
{
    public Transform posOpen;
    public Transform posDefault;
    private bool open = false;
    private bool switch1 = false;
    private bool switch2 = false;

    private void UpdateDoorState()
    {
        if (switch1 == true && switch2 == true)
        {
            OpenDoor();

        }
        else if (switch1 == false || switch2 == false)
        {
            Invoke("CloseDoor", 8f);
        } 
    }

    private void OpenDoor()
    {
        if (open == false)
        {
            transform.position = posOpen.transform.position;
            open = true;
            Debug.Log("open - true");
        }

    }

    private void CloseDoor()
    {      
        if (open == true)
        {
            transform.position = posDefault.transform.position;
            open = false;
            Debug.Log("open - false");
        }
    }

    public void Switch1()
    {
        if (switch1 == true)
        {
            switch1 = false;
            Debug.Log("Switch 1 - false");
        }
        else
        {
            switch1 = true;
            Debug.Log("Switch 1 - true");
        }

        UpdateDoorState();
    }

    public void Switch2()
    {
        if (switch2 == true)
        {
            switch2 = false;
            Debug.Log("Switch 2 - false");
        }
        else
        {
            switch2 = true;
            Debug.Log("Switch 2 - true");
        }

        UpdateDoorState();
    }
}
