using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -1f)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
