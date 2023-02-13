using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SimulationDisplay : MonoBehaviour
{
    public static SimulationDisplay instance{get; private set;}

    [Header("Scriptable Object")]
    [SerializeField] private BatteryData batteryData;
    [Header("Image")]
    [SerializeField] private Image solarPanelImage;
    [SerializeField] private Image converterImage;
    [SerializeField] private Image batteryImage;
    [SerializeField] private Image circuitEletricalImage;
    [SerializeField] private Image lampImage;
    [SerializeField] private Image lampOutsideImage;
    [SerializeField] private Image televisionImage;
    [SerializeField] private Image waterPumpImage;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI solarPanelText;
    [SerializeField] private TextMeshProUGUI batteryText;
    [SerializeField] private TextMeshProUGUI lampInsideText;
    [SerializeField] private TextMeshProUGUI lampOutsideText;
    [SerializeField] private TextMeshProUGUI televisionText;
    [SerializeField] private TextMeshProUGUI waterPumpText;

    void OnEnable()
    {
        StartCoroutine(UpdateStatusEverySecond());
    }

    IEnumerator UpdateStatusEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            solarPanelText.text = BatteryEletricalReceiver.instance.solarPanelData.name;
            batteryText.text = BatteryEletricalReceiver.instance.batteryData.name;
        
            solarPanelImage.color = colorHandler(isBatteryHaveInput());
            converterImage.color = colorHandler(true);
            batteryImage.color = colorHandler(isBatteryHaveCurrent());
            circuitEletricalImage.color = colorHandler(isBatteryHaveOutput());
            lampImage.color = colorHandler(isAddWattUsage("LampInside"));
            lampOutsideImage.color = colorHandler(isAddWattUsage("LampOutside"));
            televisionImage.color = colorHandler(isAddWattUsage("Television"));
            waterPumpImage.color = colorHandler(isAddWattUsage("WaterPump"));

            lampInsideText.text = $"{UsageManager.instance.GettWatt("LampInside").ToString()} WH";
            lampOutsideText.text = $"{UsageManager.instance.GettWatt("LampOutside").ToString()} WH";
            televisionText.text = $"{UsageManager.instance.GettWatt("Television").ToString()} WH";
            waterPumpText.text = $"{UsageManager.instance.GettWatt("WaterPump").ToString()} WH";   
        }
    }

    bool isAddWattUsage(string name)
    {
        if (UsageManager.instance.GettWatt(name) == 0)
        {
            return false;
        }

        if (batteryData.currentBattery == 0)
        {
            return false;
        }
        return true;
    }

    bool isBatteryHaveCurrent()
    {
        if (batteryData.currentBattery == 0)
        {
            return false;
        }
        return true;
    }

    bool isBatteryHaveOutput()
    {
        if (batteryData.outputBattery == 0)
        {
            return false;
        }

        if (batteryData.currentBattery == 0)
        {
            return false;
        }
        return true;
    }
    bool isBatteryHaveInput()
    {
        if (BatteryEletricalReceiver.instance.inputBattery == 0)
        {
            return false;
        }
        return true;
    }

    Color32 colorHandler(bool condition)
    {
        if (!condition)
        {
            return new Color32(214, 48, 4, 255);
        }

        return new Color32(116, 185, 255, 255);
    }
}
