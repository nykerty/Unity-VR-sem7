using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

[System.Serializable]
public class Record
{
    public string Name;
    public float Time;
}

[System.Serializable]
public class RecordData
{
    public List<Record> Records = new List<Record>();
}

public class RecordsManager : MonoBehaviour
{
    public Text RecordText;
    public Text NameInput; // ��������� ���� ��� ����� ����� ������
    public InputField inputField;
    public GameObject InputRevealBtn;
    public GameObject NameInputPanel; // ������ � ��������� ����� ��� ����� �����
    public GameObject GenerateNameBtn;

    private string recordsPath = "Assets/Records.json"; // ���� � ����� � ��������
    private RecordData recordData; // ������ �� ����� � ��������
    private float newRecordTime = 0;

    public static RecordsManager instance;

    void Start()
    {
        instance = this;
        // �������� �������� �� �����
        LoadRecords();

        // ����� ������ �� �����
        DisplayRecords();

        // �������� ������ � ��������� ����� ��� ����� �����
        NameInputPanel.SetActive(false);
        InputRevealBtn.SetActive(false);
        GenerateNameBtn.SetActive(false);
    }

    // ����� ������ �� �����
    private void DisplayRecords()
    {
        RecordText.text = ""; // ������� �����

        for (int i = 0; i < recordData.Records.Count; i++)
        {
            RecordText.text += $"{i + 1}. {recordData.Records[i].Name}: {recordData.Records[i].Time:F2}\n";
        }
    }

    // �������� ������ �������
    public void NewRecordCheck(float newTime)
    {
        // ��������� ������� �� ������� � ������� �����������
        recordData.Records = recordData.Records.OrderBy(x => x.Time).ToList();

        // ���������, ����� �� ����� ��������� � ���-5
        if (recordData.Records.Count < 5 || newTime < recordData.Records[4].Time)
        {
            // ���������� ��������� ���� ��� ����� �����
            NameInputPanel.SetActive(true);
            InputRevealBtn.SetActive(true);
            GenerateNameBtn.SetActive(true);
            newRecordTime = newTime;
        }
        else
        {
            // ������ ��������� ���� ��� ����� �����
            NameInputPanel.SetActive(false);
            InputRevealBtn.SetActive(false);
            GenerateNameBtn.SetActive(false);
        }
    }

    // ���������� ����� ����� (���������� ��� ������� ������ "OK" � ������)
    public void OnNameInputSubmitted()
    {
        // ��������� ����� ������ � ������
        recordData.Records.Add(new Record { Name = inputField.text, Time = newRecordTime });

        // ��������� ������ �����
        recordData.Records = recordData.Records.OrderBy(x => x.Time).ToList();

        // ������� 6-� �������, ���� ������ ������ 5
        if (recordData.Records.Count > 5)
        {
            recordData.Records.RemoveAt(5);
        }

        // ��������� ����������� ������ ��������
        SaveRecords();

        // ��������� ����������� ��������
        DisplayRecords();

        // �������� ������ � ��������� ����� ��� ����� �����
        NameInputPanel.SetActive(false);
        InputRevealBtn.SetActive(false);
        GenerateNameBtn.SetActive(false);
    }

    // ����� ��� ���������� �������� � ����
    private void SaveRecords()
    {
        string jsonData = JsonUtility.ToJson(recordData);
        File.WriteAllText(recordsPath, jsonData);
    }

    // ����� ��� �������� �������� �� �����
    private void LoadRecords()
    {
        if (File.Exists(recordsPath))
        {
            string jsonData = File.ReadAllText(recordsPath);
            recordData = JsonUtility.FromJson<RecordData>(jsonData);
        }
        else
        {
            // ���� ���� �� ������, ������� ����� ������ ��������
            recordData = new RecordData();
            SaveRecords();  
        }
    }
}