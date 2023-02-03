using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject turret;
    [SerializeField] GameObject fox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnEnemey(GameObject unit,float distance)
    {
        SpawnEnemyInternal(unit, distance);
    }
    private void SpawnEnemyInternal(GameObject unit,float distance)
    {
        float rand = UnityEngine.Random.value;
        double radians = (rand*150/360 * 2 * Math.PI) +(285f/360f)*2*Math.PI;
        Vector3 v = getv(radians)*distance;
        Quaternion quat = Quaternion.FromToRotation(turret.transform.position,  v); //the direction from spawn to turret
        GameObject obj = Instantiate(unit,v,quat);
    }
    private Vector3 getv(double radians)
    {
        return new Vector3((float)Math.Sin(radians), (float)Math.Cos(radians),0);
    }
    

}
