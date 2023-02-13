using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite interactIcon;
    public Vector2 iconSize;
    [TextArea(3,10)]
    public String interactText;
    
    public int ID;
    void Start()
    {
        ID = UnityEngine.Random.Range(0,999999);
    }
    public void Invoked()
    {
        onInteract.Invoke();
    }
}
