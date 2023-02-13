using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCurrentPowerConsumptionController : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] private BatteryData batteryData;

    [Header("Image and Color")]
    [SerializeField] private Image sliderOfCurrentPowerConsumption;
    [SerializeField] private Color beginColor, endColor;

    void Update()
    {
        float currentPowerConsumptionValue = batteryData.outputBattery / batteryData.wattTransferCapacity;
        sliderOfCurrentPowerConsumption.fillAmount = Mathf.Lerp(0, 1, currentPowerConsumptionValue);
        sliderOfCurrentPowerConsumption.color = Color.Lerp(beginColor, endColor, currentPowerConsumptionValue);   
    }
}
