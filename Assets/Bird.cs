using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound("bird");
        AudioManager.instance.SetVolume("bird", 0.7f);
    }
}
