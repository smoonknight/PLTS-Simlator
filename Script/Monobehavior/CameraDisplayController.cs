using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraDisplayController : MonoBehaviour
{
    [SerializeField] private List<SecurityCameraData> securityCameraDatas;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private TextMeshProUGUI titleText;
    int onWatchElement;
    int securityCameraDataCount;

    void Start()
    {
        securityCameraDataCount = securityCameraDatas.Count;

        ReplaceTextureAndTitle(onWatchElement);
    }
    public void ForwardButtonTrigger()
    {
        AudioManager.instance.Play("SFX_Pop");
        onWatchElement++;
        onWatchElement = onWatchElement > securityCameraDataCount - 1 ? 0 : onWatchElement;

        ReplaceTextureAndTitle(onWatchElement);
    }

    public void BackwardButtonTrigger()
    {
        AudioManager.instance.Play("SFX_Pop");
        onWatchElement--;
        onWatchElement = onWatchElement < 0 ? securityCameraDataCount - 1 : onWatchElement;
        
        ReplaceTextureAndTitle(onWatchElement);
    }

    public void ReplaceTextureAndTitle(int element)
    {
        cameraTransform.SetPositionAndRotation(securityCameraDatas[element].location, Quaternion.Euler(securityCameraDatas[element].rotation));
        titleText.text = securityCameraDatas[element].name;
    }
}
