using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Security;
using UnityEngine;

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

    public void PlaySound(string name)
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
            audioSources[name].Play();
        }
        else
        {
            Debug.LogError("Sound: " + name + " not found!");
        }
    }
}
