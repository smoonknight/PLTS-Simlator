using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletronicOutputUsage : MonoBehaviour
{
    [Header("Monobehavior")]
    [SerializeField] private Interactable interactable;

    [Header("Scriptable Object")]
    [SerializeField] private EletronicalUsageData eletronicalUsageData;
    [SerializeField] private BatteryData batteryData;
    [SerializeField] private DateAndTimeDisplayData dateAndTimeDisplayData;

    [Header("Renderer and Light")]
    [SerializeField] private MeshRenderer rendererToChange;
    [SerializeField] private Light lightSource;
    
    private void FixedUpdate()
    {
        if (lightSource.enabled)
        {
            if (batteryData.currentBattery < eletronicalUsageData.watt)
            {
                interactable.Invoked();
            }
        }
    }
    public void Turn()
    {
        if (lightSource)
        {
            lightSource.enabled = true;
        }
        rendererToChange.enabled = true;
    }

    public void Shut()
    {
        if (lightSource)
        {
            lightSource.enabled = false;
        }
        rendererToChange.enabled = false;
    }
}
