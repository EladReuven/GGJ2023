using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.WaterPickup.Invoke();
        Destroy(gameObject);        
    }
}
