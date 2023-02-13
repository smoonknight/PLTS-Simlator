using UnityEngine;

[CreateAssetMenu(fileName = "SetupOnLoad", menuName = "SetupOnLoad")]
public class SetupOnLoad : ScriptableObject 
{
    public SolarPanelData solarPanelData;
    public BatteryData batteryData;
}