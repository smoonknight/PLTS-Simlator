using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOfObject;
    
    Toggle toggle;
    private void Start() 
    {
        toggle = gameObject.GetComponent<Toggle>();
    }
    public void Toggle()
    {
        gameOfObject.SetActive(toggle.isOn);
    }
}
