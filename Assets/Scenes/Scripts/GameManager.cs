using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGameRunning = false;
    public float startTime = 40f;

    public GameObject snowmanPrefab;
    public GameObject snowballAmmoPrefab;

    public Text timerText;
    public Text TreeHPText;
    private float currentTime;

    public Transform phase1_coord1;
    public Transform phase1_coord2;
    public Transform phase2_coord1;
    public Transform phase2_coord2;
    public Transform phase3_coord1;
    public Transform phase3_coord2;

    public static GameManager instance;

    private IEnumerator phase1;
    private IEnumerator phase2;
    private IEnumerator phase3;
    private bool phase2Started = false;
    private bool phase3Started = false;

    private bool isAmmoSpawned = false;


    void Start()
    {
        instance = this;
        currentTime = startTime;
        phase1 = SpawnSnowmenPhase1();
        phase2 = SpawnSnowmenPhase2();
        phase3 = SpawnSnowmenPhase3();
    }

    void Update()
    {
        if (isGameRunning)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("F1");

            if (currentTime < startTime - 10 && !phase2Started) //phase2 start
            {
                StartCoroutine(phase2);
                phase2Started = true;
            }
            if (currentTime < startTime - 25 && !phase3Started) //phase3 start
            {
                StartCoroutine(phase3);
                phase3Started = true;
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
                isGameRunning = false;
                GameWin();
            }
        }
    }

    public void TreeHP(int HP)
    {
        TreeHPText.text = "ÕÏ - " + HP;
    }

    public void GameStart()
    {
        isAmmoSpawned = false;
        isGameRunning = true;
        TreeHP(10);
        StartCoroutine(phase1);
    }

    public void GameLose()
    {
        isGameRunning = false;
        currentTime = 0;
        StopAllCoroutines();
        DeleteSnowmenAndSnowballs();
        timerText.text = "ÏÎÐÀÆÅÍÈÅ";

        Invoke("RestartALL", 4f);
    }

    private void GameWin()
    {
        isGameRunning = false;
        currentTime = 0;
        StopAllCoroutines();
        DeleteSnowmenAndSnowballs();
        timerText.text = "ÏÎÁÅÄÀ";

        Invoke("RestartALL", 4f);
    }

    private void RestartALL()
    {
        GameStarter.instance.RestartGame();
        NOVIGODBeh.instance.RestartGame();
        if (isAmmoSpawned == false)
        {
            Instantiate(snowballAmmoPrefab, new Vector3(6.5f, 1f, -3f), Quaternion.Euler(0f, 0f, 0f));
            isAmmoSpawned = true;
        }
        

        phase2Started = false;
        phase3Started = false;

        currentTime = startTime;
        TreeHPText.text = "";
        timerText.text = "";
    }

    private void DeleteSnowmenAndSnowballs()
    {
        GameObject[] allSnowmen = GameObject.FindGameObjectsWithTag("Snowman");
        GameObject[] snowballPacks = GameObject.FindGameObjectsWithTag("snowballPack");
        foreach (GameObject obj in allSnowmen)
        {
            Destroy(obj, 1f);
        }
        foreach (GameObject obj in snowballPacks)
        {
            Destroy(obj, 1f);
        }
    }

    private IEnumerator SpawnSnowmenPhase1()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(5f);
            float x = Random.Range(phase1_coord1.position.x, phase1_coord2.position.x);
            float z = Random.Range(phase1_coord1.position.z, phase1_coord2.position.z);

            Instantiate(snowmanPrefab, new Vector3(x, 0.35f, z), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    private IEnumerator SpawnSnowmenPhase2()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(5f);
            float x = Random.Range(phase2_coord1.position.x, phase2_coord2.position.x);
            float z = Random.Range(phase2_coord1.position.z, phase2_coord2.position.z);

            Instantiate(snowmanPrefab, new Vector3(x, 0.35f, z), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    private IEnumerator SpawnSnowmenPhase3()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(5f);
            float x = Random.Range(phase3_coord1.position.x, phase3_coord2.position.x);
            float z = Random.Range(phase3_coord1.position.z, phase3_coord2.position.z);

            Instantiate(snowmanPrefab, new Vector3(x, 0.35f, z), Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
