using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricWaterPumpController : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] private BatteryDisplayData batteryDisplayData;
    [SerializeField] private EletronicalUsageData eletronicalUsageData;
    [SerializeField] private BatteryData batteryData;

    [Header("Gameobject and Location")]
    [SerializeField] private GameObject particlePrefabs;
    [SerializeField] private Vector3 location;

    GameObject prefabLoader;
    bool condition;

    public void TurnOnWaterPump()
    {
        if (condition)
        {
            Shut();
        }
        else 
        {
            Turn();
        }
    }

    public void Turn()
    {
        prefabLoader = SpawnManager.instance.Add("WaterSprinkler");
        UsageManager.instance.AddUsage("WaterPump", eletronicalUsageData.watt);
        condition = true;
    }
    public void Shut()
    {
        Destroy(prefabLoader);
        UsageManager.instance.RemoveUsage("WaterPump", eletronicalUsageData.watt);
        condition = false;
    }
}
