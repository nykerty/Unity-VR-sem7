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
    public Text NameInput; // Текстовое поле для ввода имени игрока
    public GameObject InputRevealBtn;
    public GameObject NameInputPanel; // Панель с текстовым полем для ввода имени

    private string recordsPath = "Assets/DisRecords.json"; // Путь к файлу с записями
    private DisRecordData recordData; // Данные из файла с записями
    private float newRecordTime = 0;

    public static DisRecordManager instance;

    void Start()
    {
        instance = this;
        // Загрузка рекордов из файла
        LoadRecords();

        // Вывод данных на экран
        DisplayRecords();

        // Скрываем панель с текстовым полем для ввода имени
        NameInputPanel.SetActive(false);
        InputRevealBtn.SetActive(false);
    }

    // Вывод данных на экран
    private void DisplayRecords()
    {
        RecordText.text = ""; // Очищаем текст

        for (int i = 0; i < recordData.Records.Count; i++)
        {
            RecordText.text += $"{i + 1}. {recordData.Records[i].Name}: {recordData.Records[i].Time:F2}\n";
        }
    }

    // Проверка нового рекорда
    public void NewRecordCheck(float newTime)
    {
        // Сортируем рекорды по времени в порядке возрастания
        recordData.Records = recordData.Records.OrderBy(x => x.Time).ToList();

        // Проверяем, попал ли новый результат в топ-5
        if (recordData.Records.Count < 5 || newTime < recordData.Records[4].Time)
        {
            // Показывать текстовое поле для ввода имени
            InputRevealBtn.SetActive(true);
            newRecordTime = newTime;
        }
        else
        {
            // Скрыть текстовое поле для ввода имени
            InputRevealBtn.SetActive(false);
        }
    }

    // Обработчик ввода имени (вызывается при нажатии кнопки "OK" в панели)
    public void OnNameInputSubmitted()
    {
        // Добавляем новый рекорд в список
        recordData.Records.Add(new DisRecord { Name = NameInput.text, Time = newRecordTime });

        // Сортируем список снова
        recordData.Records = recordData.Records.OrderBy(x => x.Time).ToList();

        // Удаляем 6-й элемент, если список больше 5
        if (recordData.Records.Count > 5)
        {
            recordData.Records.RemoveAt(5);
        }

        // Сохраняем обновленный список рекордов
        SaveRecords();

        // Обновляем отображение рекордов
        DisplayRecords();

        // Скрываем панель с текстовым полем для ввода имени
        NameInputPanel.SetActive(false);
    }

    // Метод для сохранения рекордов в файл
    private void SaveRecords()
    {
        string jsonData = JsonUtility.ToJson(recordData);
        File.WriteAllText(recordsPath, jsonData);
    }

    // Метод для загрузки рекордов из файла
    private void LoadRecords()
    {
        if (File.Exists(recordsPath))
        {
            string jsonData = File.ReadAllText(recordsPath);
            recordData = JsonUtility.FromJson<DisRecordData>(jsonData);
        }
        else
        {
            // Если файл не найден, создаем новый список рекордов
            recordData = new DisRecordData();
        }
    }
}