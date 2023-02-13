using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Battery", menuName = "Battery")]
public class BatteryData : ScriptableObject
{
    public new string name;
    public float voltBattery = 12;
    public float ampereBattery = 33;
    public float wattTransferCapacity = 200;

    public float outputBattery;
    public float currentBattery;
    public float lastHourCurrentBattery;
    public float lastHourInputBattery;

    public void clear()
    {
        outputBattery = 0;
        currentBattery = 0;
        lastHourCurrentBattery = 0;
        lastHourInputBattery = 0;
    }
}
