using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private List<Vector3> transformCharacter;

    int transformCharacterCounter;


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            DoAnimate();
            transformCharacterCounter = 0;
        }
    }

    void DoAnimate()
    {
        if(transformCharacterCounter != transformCharacter.Count)
        {
            character.transform.LeanMoveLocal(transformCharacter[transformCharacterCounter], 1).setOnComplete(DoAnimate);
            transformCharacterCounter++;
        }
    }
}
