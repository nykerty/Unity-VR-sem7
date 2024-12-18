using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CraftManager : MonoBehaviour
{
    public Transform[] sockets;
    public Transform[] items;

    public Transform spawnPos;
    public GameObject gunPrefab;

    public GameObject KubikSema;
    public Text SemaTalk;
    public GameObject RECIPE;
    public Transform PlayerCamera;

    private bool[] socketFilled;

    private XRBaseInteractable socketitem;

    void Update()
    {
        WatchPlayer();
    }

    private void WatchPlayer()
    {
        KubikSema.transform.LookAt(PlayerCamera.position);
    }

    private void Start()
    {
        socketFilled = new bool[sockets.Length];
    }

    public void OnItemInserted()
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            socketitem = sockets[i].GetComponent<XRSocketInteractor>().selectTarget;
            if (socketitem != null)
            {
                if (sockets[i].tag == socketitem.tag && !socketFilled[i])
                {
                    socketFilled[i] = true;
                    break;
                }
            }    
        }
        CheckProgress();
    }

    public void OnItemRemoved(int socketIndex)
    {
        if (socketIndex >= 0 && socketIndex < socketFilled.Length)
        {
            socketFilled[socketIndex] = false;
            CheckProgress();
        }
    }

    private void CheckProgress()
    {
        int progress = 0;
        for (int i = 0; i < socketFilled.Length; i++)
        {
            if (socketFilled[i])
            {
                progress++;
            }
        }

        Debug.Log("Current Progress: " + progress);
        if (progress == sockets.Length)
        {

            for (int j = 0; j < items.Length; j++)
            {
                Destroy(sockets[j].gameObject); 
                Destroy(items[j].gameObject);
            }

            Invoke("SpawnGun", 1.5f);
            NewTalkSema();

            for (int i = 0; i < socketFilled.Length; i++)
            {
                socketFilled[i] = false;
            }

        }
    }

    private void NewTalkSema()
    {
        SemaTalk.text = "В снегомете 10 снежков, перезаряжай его снежками после смерти снеговиков\nА теперь выстрели пару раз в снеговика у елки, чтобы начать ОБОРОНУ";
        RECIPE.gameObject.SetActive(false);
    }

    private void SpawnGun()
    {
        Instantiate(gunPrefab, spawnPos.position, Quaternion.Euler(90f, 0f, -90f));
    }
}