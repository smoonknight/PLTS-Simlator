using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    
    public void AudioUsage(string audioName)
    {
        AudioManager.instance.Play(audioName);
    }
    public void ToogleBool(string boolname)
    {
        animator.SetBool(boolname, !animator.GetBool(boolname));
    }
}
