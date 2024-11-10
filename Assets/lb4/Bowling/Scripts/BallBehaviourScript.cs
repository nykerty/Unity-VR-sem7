using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallBehaviourScript : MonoBehaviour
{
    public Transform respawnPoint;
    private bool isHitted = false;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BowlingPin" && !isHitted)
        {
            isHitted = true;
            Invoke("TeleportToResp", 5.0f);      
        }
        else if (other.gameObject.tag == "Respawn")
        {
            CancelInvoke();
            TeleportToResp();           
        }   
        else if (other.gameObject.tag == "Anything")
        {
            CancelInvoke();
            Invoke("TeleportToResp", 2.0f);
        }
    }

    void TeleportToResp()
    {
        transform.position = respawnPoint.transform.position;
        isHitted = false;
        GameManager.instance.NewThrow();
    }


}
