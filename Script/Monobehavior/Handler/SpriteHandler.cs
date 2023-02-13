using System.Runtime.Serialization;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteHandler : MonoBehaviour
{
    [SerializeField] private Image stateImage;
    [SerializeField] private Sprite onStateImage;
    [SerializeField] private Sprite offStateImage;
    [SerializeField] private Light sourceOfLight;

    bool isOnState;
    void Update()
    {
        if(sourceOfLight != null)
        {
            if(sourceOfLight.enabled)
            {
                stateImage.sprite = onStateImage;
            }
            else
            {
                stateImage.sprite = offStateImage;
            }
        }
    }
}
