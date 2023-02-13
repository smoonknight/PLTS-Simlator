using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.StopAll();
        Cursor.lockState = CursorLockMode.None;
        AudioManager.instance.Play("Music_Potato", true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
