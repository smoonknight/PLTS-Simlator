using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Date Time", menuName = "Date Time")]
public class DateAndTimeDisplayData : ScriptableObject
{
    public string time;
    public string day;
    public float hourInElapse;

}
