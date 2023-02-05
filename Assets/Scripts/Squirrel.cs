using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound("squirrel");
        AudioManager.instance.PlaySound("fox");
    }

    private void OnDestroy()
    {
        AudioManager.instance.PauseSound("fox");
    }
}
