using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    [SerializeField] private GameObject phone;
    [SerializeField] private PhoneAnimate phoneAnimate;
    FirstPersonController firstPersonController;

    bool isPhoneActive = false;

    void Start()
    {
        firstPersonController = gameObject.GetComponent<FirstPersonController>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            isPhoneActive = phone.activeSelf; 
            if (!isPhoneActive)
            {
                List<LandscapeUIController> landscapeUIControllers = GameObject.FindObjectsOfType<LandscapeUIController>().ToList();

                foreach (LandscapeUIController landscapeUIController in landscapeUIControllers)
                {
                    landscapeUIController.CloseLandscape();
                }
                Cursor.lockState = CursorLockMode.None;
                firstPersonController.enabled = false;
                phoneAnimate.gameObject.SetActive(true);
            }
            else{
                Cursor.lockState = CursorLockMode.Locked;
                firstPersonController.enabled = true;
                phoneAnimate.StartDisasspear();
            }
        }
    }
}
