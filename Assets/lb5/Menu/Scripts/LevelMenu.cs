using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        string CurrentLevel = gameObject.scene.name;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
