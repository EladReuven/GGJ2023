using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRaySpawner : MonoBehaviour
{
    [SerializeField] float upperTimeRange;
    [SerializeField] float lowerTimeRange;
    float t;
     float time;
    [SerializeField] GameObject lightRay;
    [SerializeField] Transform exampleTransform;
    public void Start()
    {
        t = 0;

        time = Random.Range(lowerTimeRange, upperTimeRange);
    }
    public void Update()
    {
        t += Time.deltaTime;
        if (t > time)
        {
            print("here");
            t = 0;
            time = Random.Range(lowerTimeRange, upperTimeRange);
            SpawnRay();
        }
    }

    public void SpawnRay()
    {
        Instantiate(lightRay, exampleTransform.position,exampleTransform.rotation);
    }
}
