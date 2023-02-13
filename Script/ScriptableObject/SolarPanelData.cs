using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Solar Panel", menuName = "Solar Panel")]
public class SolarPanelData : ScriptableObject
{
    public new string name = "100w Solar Panel";
    public float maximumWatt = 100f;
    public float maximumVolt = 17.8f;
    public float maximumAmpere = 5.62f;
}
