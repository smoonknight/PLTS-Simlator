using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsageManager : MonoBehaviour
{
    public static UsageManager instance {get; private set;}
    private void Awake() 
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    [SerializeField] private BatteryData batteryData;

    public WattUsage[] wattUsages;

    public void OnStart()
    {
        foreach (WattUsage wattUsage in wattUsages)
        {
            wattUsage.eletronicalUsageData.Clear();
        }
    }

    public void UpdateHour()
    {
        WattUsage[] wattUsageList = Array.FindAll(wattUsages, wattUsage => wattUsage.watt != 0);
        foreach (WattUsage wattUsage in wattUsageList)
        {
            wattUsage.eletronicalUsageData.totalUsage += 1;
        }
    }

    public void AddUsage(string name, float watt)
    {
        WattUsage wattUsage = Array.Find(wattUsages, wattUsage => wattUsage.name == name);
        wattUsage.watt += watt;
        batteryData.outputBattery += watt;
    }

    public void RemoveUsage(string name, float watt)
    {
        WattUsage wattUsage = Array.Find(wattUsages, wattUsage => wattUsage.name == name);
        wattUsage.watt -= watt;
        batteryData.outputBattery -= watt;
    }

    public float GettWatt(string name)
    {
        WattUsage wattUsage = Array.Find(wattUsages, wattUsage => wattUsage.name == name);
        return wattUsage.watt;
    }

}