using System.Net.Mime;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputRealTime : MonoBehaviour
{
    [SerializeField] private SolarPanelData[] solarPanelDatas;
    [SerializeField] private BatteryData[] batteryDatas;

    [SerializeField] private TMP_Dropdown dropdownSolarPanel;
    [SerializeField] private TMP_Dropdown dropdownBattery;

    [Header("List")]
    [SerializeField] private List<TMP_InputField> inputFields;

    #region SetDropdown
    private void Start()
    {
        foreach (SolarPanelData solarPanelData in solarPanelDatas)
        {
            dropdownSolarPanel.AddOptions(new List<string> {solarPanelData.name});
        }

        foreach (BatteryData batteryData in batteryDatas)
        {
            dropdownBattery.AddOptions(new List<string> {batteryData.name});
        }
    }
    #endregion

    public void GenerateRealTime()
    {
        string dropdownBatteryText = dropdownBattery.captionText.text;
        string dropdownSolarPanelText = dropdownSolarPanel.captionText.text;

        BatteryData batteryData = GetBatteryByName(dropdownBatteryText);
        SolarPanelData solarPanelData = GetSolarPanelByName(dropdownSolarPanelText);

        DataGenerator.instance.GenerateData(batteryData,solarPanelData, convertInputFieldsToList());
    }

    public void GenerateDummy()
    {
        string dropdownBatteryText = dropdownBattery.captionText.text;
        string dropdownSolarPanelText = dropdownSolarPanel.captionText.text;
        
        BatteryData batteryData = GetBatteryByName(dropdownBatteryText);
        SolarPanelData solarPanelData = GetSolarPanelByName(dropdownSolarPanelText);
        
        DataGenerator.instance.GenerateData(batteryData, solarPanelData);
    }

    private SolarPanelData GetSolarPanelByName(string name)
    {
        SolarPanelData solarPanelData = Array.Find(solarPanelDatas, solarPanelData => solarPanelData.name == name);
        Debug.Log(name);
        return solarPanelData;
    }

    private BatteryData GetBatteryByName(string name)
    {
        BatteryData batteryData = Array.Find(batteryDatas, batteryData => batteryData.name == name);
        return batteryData;
    }

    private List<float> convertInputFieldsToList()
    {
        List<float> data = new List<float>();

        foreach (TMP_InputField tMP_InputField in inputFields)
        {
            data.Add(float.Parse(tMP_InputField.text));
        }

        return data;
    }
}
