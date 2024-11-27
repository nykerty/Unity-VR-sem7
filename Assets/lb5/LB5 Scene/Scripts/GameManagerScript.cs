using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Transform[] sockets; // ������ XR Socket
    public Transform[] items;
    public Transform AKsocket;
    public Transform AK;
    public Text TimerText;

    private bool IsChallengeRunning = false;
    private int AssembledState = 1;
    private int currentStep = 0;

    private float startTime = 0;
    private float currTime = 0;
    private float endTime = 0;


    private void Start()
    {
        // ��������� ��� ��������, ����� �������
        for (int i = 1; i < sockets.Length; i++)
        {
            sockets[i].gameObject.GetComponent<Collider>().enabled = false;
        }
    }


    public void OnPartInserted(Collider socket)
    {
        // ��������, ��� ������� ��������� � ���������� ����
        if (socket.name == sockets[currentStep].name)
        {
            currentStep++;
            if (currentStep < sockets.Length)
            {
                Debug.Log("inserted " + currentStep + " / 7");
                sockets[currentStep].gameObject.GetComponent<Collider>().enabled = true; // �������� ��������� �����
                items[currentStep - 1].gameObject.GetComponent<Collider>().enabled = false; // ��������� ������� �������
            }
            else
            {
                Debug.Log("assemled " + currentStep + " / 7");
            }
        }
    }

    public void OnPartRemoved(Collider socket)
    {
        // ��������, ��� ���������� ������� �������
        if (socket.name == sockets[currentStep - 1].name)
        {
            currentStep--;
            if (currentStep > 0)
            {
                Debug.Log("removed " + currentStep + " / 7");
                sockets[currentStep].gameObject.GetComponent<Collider>().enabled = false; // ��������� ������� �����
                items[currentStep - 1].gameObject.GetComponent<Collider>().enabled = true; // �������� ��������� �������
            }
            else
            {
                Debug.Log("disassemled " + currentStep + " / 7");
                AssembledState = 2;
            }
        }
    }

    public void OnAKInserted()
    {
        if (AssembledState == 2)
        {
            Debug.Log("YES");
            IsChallengeRunning = false;
            RecordsManager.instance.NewRecordCheck(endTime);
        }
    }

    public void OnAKRemoved()
    {
        if (!IsChallengeRunning)
        {
            IsChallengeRunning = true;
            AssembledState = 1;
            startTime = Time.time;
        }
    }

    private void Update()
    {
        if (IsChallengeRunning)
        {
            currTime = Time.time;
            endTime = currTime - startTime;
            TimerText.text = endTime.ToString("F2"); // ���������� ����� 
        }
    }
}
