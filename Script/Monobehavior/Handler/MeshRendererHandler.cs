using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererHandler : MonoBehaviour
{
    [Header("Monobehavior")]
    [SerializeField] private EletronicOutputUsage eletronicOutputUsage;

    [Header("Scriptable Object")]
    [SerializeField] private EletronicalUsageData eletronicalUsageData;
    [SerializeField] private BatteryData batteryData;

    [Header("String")]
    [SerializeField] string nameObject;

    MeshRenderer rendererObject;
    private void Start()
    {
        rendererObject = gameObject.GetComponent<MeshRenderer>();
    }
    public void ToggleRenderer()
    {
        if (rendererObject.enabled)
        {
            eletronicOutputUsage.Shut();
            UsageManager.instance.RemoveUsage(nameObject, eletronicalUsageData.watt);
        }
        else
        {
           eletronicOutputUsage.Turn();
           UsageManager.instance.AddUsage(nameObject, eletronicalUsageData.watt);
        }
    }
}
