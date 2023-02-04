using UnityEngine;
using System.Collections.Generic;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] audioClips;
    private Dictionary<string, AudioSource> audioSources;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSources = new Dictionary<string, AudioSource>();
    }

    public void PlaySound(string name, bool loop = false)
    {
        AudioClip clip = Array.Find(audioClips, item => item.name == name);
        if (clip != null)
        {
            if (!audioSources.ContainsKey(name))
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = clip;
                audioSources[name] = audioSource;
            }
            audioSources[name].loop = loop;
            audioSources[name].Play();
        }
        else
        {
            Debug.LogError("Sound: " + name + " not found!");
        }
    }

    public void PauseSound(string name)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].Pause();
        }
        else
        {
            Debug.LogError("Sound: " + name + " not found!");
        }
    }

    public void UnpauseSound(string name)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].UnPause();
        }
        else
        {
            Debug.LogError("Sound: " + name + " not found!");
        }
    }
}
