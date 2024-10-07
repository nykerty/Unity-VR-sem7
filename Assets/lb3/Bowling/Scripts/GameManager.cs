using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static int totalScore = 0;

    public GameObject ball_prefab; // Bowling Ball prefab to spawn
    public GameObject pinpack_prefab; // Bowling pin pack prefab to spawn
    public static int throwsCount = 1;
    public static int frameCount = 1;
    private bool isStrike = false;

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void AddScore(int amount)
    {
        score += amount;
        totalScore += amount;
        UIManager.instance.UpdateUI(score, totalScore, frameCount, throwsCount);
    }

    public void NewThrow()
    {
        if (isStrike == true)
        {
            totalScore += score;
            isStrike = false;
        }
        else
        {
            CheckStrike();
        }
        

        throwsCount++;
        if (throwsCount <= 2) // if throws > 2 then newframe
        {
            UIManager.instance.UpdateUI(score, totalScore, frameCount, throwsCount); // update UI
        }
        else
        {
            EndFrame();
            UIManager.instance.UpdateUI(score, totalScore, frameCount, throwsCount);
        }

        Instantiate(ball_prefab, new Vector3(23.489172f, 1.05405807f, 6.53975534f), Quaternion.identity);
    }

    public void EndFrame() // restart pins, score and throwsCount
    {
        Debug.Log("Frame ended. Total score: " + totalScore);
        PinBehaviour.ClearRemainingPins();

        throwsCount = 1;
        score = 0;
        frameCount++;

        Invoke("newPins", 2.0f);
    }

    void newPins()
    {
        Instantiate(pinpack_prefab, new Vector3(25f, 1.5f, -2.6972456f), Quaternion.Euler(0, 180, 0));
    }

    public void CheckStrike()
    {
        if (throwsCount == 1 && score == 10)
        {
            isStrike = true;
            Debug.Log("Strike!");
            EndFrame();
        }
    }
}
