using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

[System.Serializable]
public class DisRecord
{
    public string Name;
    public float Time;
}

[System.Serializable]
public class DisRecordData
{
    public List<DisRecord> Records = new List<DisRecord>();
}

public class DisRecordManager : MonoBehaviour
{
    public Text RecordText;
    public Text NameInput; // ��������� ���� ��� ����� ����� ������
    public GameObject InputRevealBtn;
    public GameObject NameInputPanel; // ������ � ��������� ����� ��� ����� �����

    private string recordsPath = "Assets/DisRecords.json"; // ���� � ����� � ��������
    private DisRecordData recordData; // ������ �� ����� � ��������
    private float newRecordTime = 0;

    public static DisRecordManager instance;

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
            InputRevealBtn.SetActive(true);
            newRecordTime = newTime;
        }
        else
        {
            // ������ ��������� ���� ��� ����� �����
            InputRevealBtn.SetActive(false);
        }
    }

    // ���������� ����� ����� (���������� ��� ������� ������ "OK" � ������)
    public void OnNameInputSubmitted()
    {
        // ��������� ����� ������ � ������
        recordData.Records.Add(new DisRecord { Name = NameInput.text, Time = newRecordTime });

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
            recordData = JsonUtility.FromJson<DisRecordData>(jsonData);
        }
        else
        {
            // ���� ���� �� ������, ������� ����� ������ ��������
            recordData = new DisRecordData();
        }
    }
}