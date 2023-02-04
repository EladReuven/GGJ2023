using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
        GameManager.Instance.WaterPickup.Invoke();
        Destroy(gameObject);        
        }
    }
}
