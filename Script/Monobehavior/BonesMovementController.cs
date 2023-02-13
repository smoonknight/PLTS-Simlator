using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesMovementController : MonoBehaviour
{
    [SerializeField] private Transform directionalLightOfTransform;
    [SerializeField] private Transform firstBoneOfTransform;
    [SerializeField] private Transform secondBoneOfTransform;
    float currentSunRotation;
    float currentSunEulerAngels;
    float percentage;

    void Update()
    {
        RotateBoneOfTrackingMachine();
    }
    
    void RotateBoneOfTrackingMachine()
    {
        currentSunRotation = directionalLightOfTransform.rotation.x;
        currentSunEulerAngels = directionalLightOfTransform.transform.eulerAngles.x;
        float firstBoneOfTransformRotation = Mathf.Lerp(0, 180, currentSunRotation);
        float secondBoneOfTransformRotation = 0;
        if (currentSunEulerAngels < 90)
        {
            secondBoneOfTransformRotation = Mathf.Lerp(65, 0, currentSunEulerAngels/90);
        }
        else
        {
            secondBoneOfTransformRotation = Mathf.Lerp(65, 0, 0);
        }
        firstBoneOfTransform.localRotation = Quaternion.Euler(0, firstBoneOfTransformRotation, 0);
        secondBoneOfTransform.localRotation = Quaternion.Euler(secondBoneOfTransformRotation, 0, 0);
    }
}
