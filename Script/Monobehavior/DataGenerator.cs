using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DataGenerator : NotificatorMessage
{
    #region singleton
    public static DataGenerator instance{get; private set;}
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #endregion
    
    [Header("Scriptable Object")]
    [SerializeField] private BatteryDisplayData batteryDisplayData;
    [SerializeField] private SolarPanelData solarPanelData;
    [SerializeField] private BatteryData batteryData;

    public void GenerateData(BatteryData batteryDataToEntry, SolarPanelData solarPanelDataToEntry, List<float> input = null)
    {
        SetBatteryData(batteryDataToEntry);
        SetSolarPanelData(solarPanelDataToEntry);
        batteryDisplayData.listInput = AddOrConvertListInputToList(input);
        LevelLoader.instance.LoadNextLevel("SimulatorScene");
    }

    public void SetBatteryData(BatteryData data)
    {
        if (data == null)
        {
             return;
        }
        batteryData.name = data.name;
        batteryData.voltBattery = data.voltBattery;
        batteryData.ampereBattery = data.ampereBattery;
        batteryData.wattTransferCapacity = data.wattTransferCapacity;
    }

    public void SetSolarPanelData(SolarPanelData data)
    {
        if (data == null)
        {
            return;
        }
        solarPanelData.name = data.name;
        solarPanelData.maximumVolt = data.maximumVolt;
        solarPanelData.maximumAmpere = data.maximumAmpere;
        solarPanelData.maximumWatt = data.maximumWatt;
    }

    public List<float> AddOrConvertListInputToList(List<float> inputData = null)
    {
        List<float> data = new List<float>();
        int count = 0;
        for (int i = 0; i < 25; i++)
        {
            if (Enumerable.Range(7, 12).Contains(i))
            {
                float value = inputData == null 
                    ? Random.Range(solarPanelData.maximumWatt/2, solarPanelData.maximumWatt) 
                    : inputData[count];
                data.Add(value);
                count++;
            }
            else
            {
                data.Add(0f);
            }
        }
        return data;
    }
}
