using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingControl : MonoBehaviour
{

    Transform turretLocation;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = turretLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
