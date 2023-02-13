using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAnimate : MonoBehaviour
{   
    public void OnEnable()
    {
        AudioManager.instance.Play("SFX_SweepUp");
        LeanTween.cancel(gameObject);
        transform.LeanMoveLocal(new Vector2(400,-100), 1).setEaseInOutBack().setOnComplete(OnStart);
    }

    public void StartDisasspear()
    {
        
        LeanTween.cancel(gameObject);
        transform.LeanMoveLocal(new Vector2(400,-800), 0.7f).setEaseInOutBack().setOnComplete(() => gameObject.SetActive(false));
    }

    public void OnStart()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
