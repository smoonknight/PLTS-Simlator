using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAndDayTextDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private DateAndTimeDisplayData dateAndTimeDisplayData;
    [SerializeField] private TextMeshProUGUI dayText;

    void Update()
    {
        if (timeText != null)
        {
            timeText.text = dateAndTimeDisplayData.time;
        }
        if (dayText != null)
        {
            dayText.text = dateAndTimeDisplayData.day;
        }
    }
}
