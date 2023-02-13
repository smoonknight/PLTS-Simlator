using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSprinklerUsage : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] private BatteryData batteryData;
    [SerializeField] private EletronicalUsageData eletronicalUsageData;

    EletricWaterPumpController eletricWaterPumpController;

    void Start()
    {
        eletricWaterPumpController = GameObject.Find("Electric motor").GetComponent<EletricWaterPumpController>();
    }
    void FixedUpdate()
    {
        float currentOfBattery = batteryData.currentBattery;
        if (currentOfBattery < eletronicalUsageData.watt)
        {
            eletricWaterPumpController.Shut();
        }
    }
}
