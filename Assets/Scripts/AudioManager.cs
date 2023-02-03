using System.Collections;
using System.Collections.Generic;
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

   

    private AudioSource GetAudioSource()
    {
        return new AudioSource();
    }
}
