using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBehaviour : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "ControllerTeleporter")
        {
            transform.position = teleportPoint.transform.position;
        }
    }

}
