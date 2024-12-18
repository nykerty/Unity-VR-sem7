using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public Light lightSource1;
    public Light lightSource2;
    public int HP = 2;

    public static GameStarter instance;

    void Awake()
    {
        instance = this;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Snowball" && HP > 0)
        {
            HP--;
        }

        if (HP == 0)
        {
            HP = 100;
            SnowmanDeath();
            GameManager.instance.GameStart();
        }
    }

    public void RestartGame()
    {
        HP = 2;
        lightSource1.enabled = true;
        lightSource2.enabled = true;
    }

    public void SnowmanDeath()
    {
        lightSource1.enabled = false;
        lightSource2.enabled = false;
    }
}
