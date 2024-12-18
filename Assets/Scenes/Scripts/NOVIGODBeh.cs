using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NOVIGODBeh : MonoBehaviour
{
    public Light[] lightSources;
    public int HP = 10;

    public static NOVIGODBeh instance;

    void Awake()
    {
        instance = this;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Snowman" && HP > 0)
        {
            Destroy(other.gameObject);
            HP--;
            GameManager.instance.TreeHP(HP);
        }

        if (HP == 0)
        {
            GameManager.instance.GameLose();
            for (int i = 0; i < lightSources.Length; i++)
            {
                lightSources[i].enabled = false;
            }
        }
    }

    public void RestartGame()
    {
        HP = 10;
        for (int i = 0; i < lightSources.Length; i++)
        {
            lightSources[i].enabled = true;
        }
    }
}
