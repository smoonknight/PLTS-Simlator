using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping : MonoBehaviour
{
    #region Singleton With Private Instance
    private static Sleeping instance;

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

    [SerializeField] private Animator animator;
    [SerializeField] private KeyCode keyCode;

    private void Start()
    {
        GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 10f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            Time.timeScale = 1f;
            animator.SetTrigger("Start");
            Destroy(gameObject, 1f);
        }
    }

    private void OnDestroy()
    {
        GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>().enabled = true;
    }
}
