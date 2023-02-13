using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    #region Singleton

    public static PausePanel instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion
    
    CursorLockMode cursorLockMode;

    private void Start()
    {
        Time.timeScale = 0f;
        GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        cursorLockMode = Cursor.lockState;

    }
    public void ResumeGame()
    {
        BackToDefault();
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
    public void ReturnToMainMenu()
    {
        BackToDefault();
        Time.timeScale = 1f;
        LevelLoader.instance.LoadNextLevel("MainMenuScene");
    }

    private void BackToDefault() 
    {
        GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = cursorLockMode;
    }
}
