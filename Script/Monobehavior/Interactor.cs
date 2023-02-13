using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayermask;
    [SerializeField] private Image interactImage;
    [SerializeField] private Sprite defaultIcon;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private Vector2 defaultIconSize;
    [SerializeField] private Sprite defaultInteractIcon;
    [SerializeField] private Vector2 defaultInteractIconSize;
    [SerializeField] private TextMeshProUGUI interactText;
    
    Interactable interactable;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayermask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                if (interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                    if (interactable.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                    }
                    else 
                    {
                        interactImage.rectTransform.sizeDelta = interactable.iconSize;
                    }
                }
                if (interactable.interactText != null)
                {
                    interactText.text = interactable.interactText;
                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.onInteract.Invoke();
                }
            }
        }
        else
        {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
            interactText.text = null;
        }
    }
}
