using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballBeh : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject, 2f);
    }
}
