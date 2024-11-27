using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText;

    void Awake()
    {
        instance = this;
    }

    public void UpdateUI(int score, int totalScore, int frameCount, int throwsCount)
    {
        scoreText.text = "‘рейм є " + frameCount + "\n" +
                            throwsCount + "й бросок" + "\n" +
                            "—чЄт - " + score + " / 10\n" +
                            "ќбщий счЄт - " + totalScore; ;
    }
}
