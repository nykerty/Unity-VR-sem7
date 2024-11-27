using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    public static string PreviousLevel;

    // Передаем имя предыдущей сцены в следующую сцену
    private void OnDestroy()
    {
        PreviousLevel = gameObject.scene.name;

        PlayerPrefs.SetString("LastScene", PreviousLevel);
    }
}


