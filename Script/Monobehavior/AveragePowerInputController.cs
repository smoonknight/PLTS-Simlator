using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AveragePowerInputController : MonoBehaviour
{
    [SerializeField] private BatteryDisplayData batteryDisplayData;
    [SerializeField] private TextMeshProUGUI text;
    void Awake()
    {
        StartCoroutine(UpdateEverySecond());
    }

    IEnumerator UpdateEverySecond()
    {
        yield return new WaitForSeconds(1);
        text.text = Average(batteryDisplayData.listInput).ToString();
        StartCoroutine(UpdateEverySecond());
    }

    float Average(List<float> data)
    {
        float average = 0;
        for(int i = 0; i < data.Count; i++)
        {
            average += data[i];
        }

        average /= data.Count;
        return average;
    }
}
