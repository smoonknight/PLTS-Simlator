using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;
    
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool isSingleUsed;

    [HideInInspector]
    public AudioSource source;
}
