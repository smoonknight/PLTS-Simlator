using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}
    
    public Sound[] sounds;
    
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = 1;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = audioMixerGroup;
        }
    }

    public void AmbianceTransition(string ambiance, string past)
    {
        Stop(past);
        Play(ambiance, true);
    }

    public void Play(string name, bool isFaded = false)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if (sound == null)
        {
            return;
        }

        if (sound.isSingleUsed)
        {
            if (sound.source.isPlaying)
            {
                return;
            }
        }
         
        if (isFaded)
        {
            sound.source.volume = 0;
            StartCoroutine(FadedIn(sound));
            return;
        }

        sound.source.Play();
    }

    public void Stop(string name, bool isFaded = false)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            return;
        }
        if (isFaded)
        {
            sound.source.volume = 1;
            StartCoroutine(FadedOut(sound));
            return;
        }
        sound.source.Stop();
    }

    public void StopAll()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }

    private IEnumerator FadedOut(Sound sound)
    {
        float elapsedTime = 0;
        while (elapsedTime <= 1f)
        {
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;
            sound.source.volume = Mathf.Lerp(1, 0, elapsedTime);
        }
        sound.source.Stop();
    }

    private IEnumerator FadedIn(Sound sound)
    {
        sound.source.Play();
        float elapsedTime = 0;
        while (elapsedTime <= 1f)
        {
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;
            sound.source.volume = Mathf.Lerp(0, 1, elapsedTime);
        }
        
    }
}
