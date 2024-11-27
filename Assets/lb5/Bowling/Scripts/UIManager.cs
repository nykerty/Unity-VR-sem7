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
        scoreText.text = "����� � " + frameCount + "\n" +
                            throwsCount + "� ������" + "\n" +
                            "���� - " + score + " / 10\n" +
                            "����� ���� - " + totalScore; ;
    }
}
