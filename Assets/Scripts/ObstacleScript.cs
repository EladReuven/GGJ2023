using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.RootHurt.Invoke();
        Destroy(gameObject);
    }
}
