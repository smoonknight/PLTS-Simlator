using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeUIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup background;
    [SerializeField] private Transform landscapePhone;
    [SerializeField] private FirstPersonController firstPersonController;
    
    GameObject phone;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        firstPersonController.enabled = false;
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);

        landscapePhone.transform.localPosition = new Vector2(0, -Screen.height - 500);
        landscapePhone.transform.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseLandscape()
    {
        if (gameObject.activeSelf)
        {
            AudioManager.instance.Play("SFX_FadeOut");
            background.LeanAlpha(0, 0.5f);
            landscapePhone.transform.LeanMoveLocalY(-Screen.height - 500, 0.5f).setEaseOutExpo().setOnComplete(new System.Action(() => gameObject.SetActive(false))).delay = 0.1f;
        }
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        firstPersonController.enabled = true;
    }
}
