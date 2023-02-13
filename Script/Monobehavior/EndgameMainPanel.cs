using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndgameMainPanel : MonoBehaviour
{
    [Header("All Panel")]
    [SerializeField] private List<GameObject> gameObjects;

    [Header("Usage Panel")]
    [SerializeField] private List<EletronicalUsageData> eletronicalUsageDatas;
    [SerializeField] private List<TextMeshProUGUI> totalUsageHourUsageTexts;
    [Header("Converter Panel")]
    [SerializeField] private SolarPanelData solarPanelData;
    [SerializeField] private BatteryDisplayData batteryDisplayData;
    [SerializeField] private TextMeshProUGUI batteryText;
    [SerializeField] private TextMeshProUGUI solarPanelText;
    [Header("Result Panel")]
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private TextMeshProUGUI messageText2;

    float averageCurrentBattery;
    float averageInputBattery;
    float averageOutputBattery;
    
    int page;


    private void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopAll();
        }
        Cursor.lockState = CursorLockMode.None;
        GetAverage();
        UsagePanel();
        ConverterPanel();
        ResultPanel();
    }

    public void SlideToRight()
    {
        Debug.Log(page);
        gameObjects[page].SetActive(false);
        page++;
        page = page > gameObjects.Count - 1 ? 0 : page;
        gameObjects[page].SetActive(true);
    }

    private void UsagePanel()
    {
        for (int i = 0; i < totalUsageHourUsageTexts.Count; i++)
        {
            totalUsageHourUsageTexts[i].text = $"{eletronicalUsageDatas[i].totalUsage} Jam";
        }
    }

    private void ConverterPanel()
    {
        batteryText.text = $"Rata-rata : {averageOutputBattery} WH";
        solarPanelText.text = $"Rata-rata : {averageInputBattery} WH";
    }

    private void ResultPanel()
    {
        float message = 
        
        (
            (
                averageInputBattery/solarPanelData.maximumWatt
            ) 
            -
            (
                averageOutputBattery/solarPanelData.maximumWatt
            )
        )*100 + 100;
        
        messageText.text = $"Hai, kamu baru saja menyelesaikan simulasi hari ini dengan menggunakan panel surya {solarPanelData.name}, efisiensi penggunaannya adalah {Mathf.Round(message)}%";
        messageText2.text = Message2();
    }

    //public void restart

    private string Message2()
    {
        if (isXBiggerThenY(averageInputBattery, averageOutputBattery))
        {
            return "Kamu telah menggunakan panel surya sesuai dengan kebutuhan";
        }
        return "Sepertinya kamu harus menganti panel surya ke yang lebih besar lagi";
    }

    private bool isXBiggerThenY(float x, float y)
    {
        if (x < y)
            return false;
        return true;
    }

    private void GetAverage()
    {
        averageCurrentBattery = MathSolve.MathAverageOnlyNotNull(batteryDisplayData.listCurrent);
        averageInputBattery = MathSolve.MathAverageOnlyNotNull(batteryDisplayData.listInput);
        averageOutputBattery = MathSolve.MathAverageOnlyNotNull(batteryDisplayData.listOutput);
    }

    public void GetLevelLoader(string condition)
    {
        LevelLoader.instance.LoadNextLevel(condition);
    }
}
