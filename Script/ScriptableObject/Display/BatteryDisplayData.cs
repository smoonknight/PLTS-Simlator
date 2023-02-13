using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Battery Display", menuName = "Battery Display")]
public class BatteryDisplayData : ScriptableObject
{
    public string inputUsage;
    public string outputUsage;
    public string currentUsage;

    public List<float> listInput;
    public List<float> listOutput;
    public List<float> listCurrent;

    public void clear()
    {
        inputUsage = null;
        outputUsage = null;
        currentUsage = null;

        listOutput.Clear();
        listCurrent.Clear();

        listOutput = new List<float>(new float[24]);
        listCurrent = new List<float>(new float[24]);
    }
}
