using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLoad : MonoBehaviour
{
    public static string PreviousLevel;

    void Start()
    {
        PreviousLevel = PlayerPrefs.GetString("LastScene");

        Debug.Log("Прошлая сцена: " + PreviousLevel);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(PreviousLevel);
    }
}
