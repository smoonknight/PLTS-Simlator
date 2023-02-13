using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LampOutputUsage : MonoBehaviour
{
    [SerializeField] private BatteryData batteryData;
    [SerializeField] private EletronicalUsageData eletronicalUsageData;
    private float wattUsage; 

    Light lampLight;
    float elapsedTime = 0.1f;
    float lightIntensity;
    void Start()
    {
        wattUsage = eletronicalUsageData.watt;
        lampLight = gameObject.GetComponent<Light>();
        lightIntensity = lampLight.intensity;
    }

    void FixedUpdate()
    {
        if (lampLight.enabled)
        {
            if (batteryData.currentBattery < wattUsage)
            {
                if (elapsedTime > 0f)
                {
                    elapsedTime = Mathf.Clamp(elapsedTime - Time.deltaTime, 0f, 1f);
                    float percentageComplete = elapsedTime/1f;
                    lampLight.intensity = Mathf.Lerp(0, lightIntensity/2, percentageComplete);
                }
            }
            else
            {
                if (elapsedTime < 1f)
                {
                    elapsedTime = Mathf.Clamp(elapsedTime + Time.deltaTime, 0f, 1f);
                    float percentageComplete = elapsedTime/1f;
                    lampLight.intensity = Mathf.Lerp(0, lightIntensity, percentageComplete);
                }
            }
        }
    }    
}