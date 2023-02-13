using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(WaitingForSecond(10));
    }

    IEnumerator WaitingForSecond(int seconds)
    {
        AudioManager.instance.Play("SFX_Rewind");
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
