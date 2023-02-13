using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    private void Update() 
    {
        if (PausePanel.instance != null)
        {
            Cursor.lockState = CursorLockMode.None;
            return;  
        }
        if (Input.GetKeyDown(pauseKey))
        {
            SpawnManager.instance.AddUI("Pause");
        }      
        
    }
}
