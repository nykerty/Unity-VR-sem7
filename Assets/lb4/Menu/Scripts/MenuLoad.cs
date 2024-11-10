using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    public void LoadBowlngScene()
    {
        SceneManager.LoadScene("BowlingScene");
    }

    public void LoadDoorsScene()
    {
        SceneManager.LoadScene("DoorsScene");
    }
}
