using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] List<AudioClip> audioClips;
    
    private AudioManager()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static AudioManager GetInstance()
    {
        if (instance==null)
        {
            instance = new AudioManager();
        }
        return instance;
    }

   public void Play(string name)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (name.Equals(clip.name))
            {
                GetAudioSource().PlayOneShot(clip);
                return;
            }
        }
        print("the clip named: " + name + " could not be found.");
    }

    private AudioSource GetAudioSource()
    {
        return new AudioSource();
    }
}
