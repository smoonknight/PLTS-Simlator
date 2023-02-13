using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryDataTextDisplayer : MonoBehaviour
{
    [SerializeField] private BatteryDisplayData batteryDisplayData;
    [SerializeField] private TextMeshProUGUI currentText;
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private TextMeshProUGUI inputText;
    void Update()
    {
        currentText.text = batteryDisplayData.currentUsage;
        outputText.text = batteryDisplayData.outputUsage;
        if (inputText != null)
        {
            inputText.text = batteryDisplayData.inputUsage;
        }
    }

}
