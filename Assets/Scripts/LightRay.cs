using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(-speed, 0, 0,ForceMode.VelocityChange);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
