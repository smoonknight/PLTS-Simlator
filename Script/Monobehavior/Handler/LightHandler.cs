using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LampOutputUsage))]
public class LightHandler : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private EletronicalUsageData eletronicalUsageData;
    [SerializeField] private BatteryData batteryData;
    [Header("Light")]
    Light lampLight;
    [Header("String")]
    [SerializeField] private string nameObject;

    void Start()
    {
        lampLight = gameObject.GetComponent<Light>();
        lampLight.enabled = false;
    }
    public void SwitchOn()
    {
        AudioManager.instance.Play("SFX_Click");
        if (lampLight.enabled)
        {
            lampLight.enabled = false;
            UsageManager.instance.RemoveUsage(nameObject, eletronicalUsageData.watt);
        }
        else
        {
            lampLight.enabled = true;
            UsageManager.instance.AddUsage(nameObject, eletronicalUsageData.watt);
        }
    }
}
