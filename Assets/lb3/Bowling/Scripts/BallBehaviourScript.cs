using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BowlingPin")
        {
            Destroy(gameObject, 5.0f);
        }
    }

    void OnDestroy()
    {
        GameManager.instance.NewThrow();
    }
}
