using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject turret;
    [SerializeField] List<GameObject> airEnemies;
    [SerializeField] List<GameObject> groundEnemies;

    public void SpawnEnemey(GameObject unit,float distance)
    {
        float rand = UnityEngine.Random.value;
        double deg = (rand * 180) + 270f;
        double radians = deg / 360f * 2 * Math.PI;
        if ((deg >= 270 && deg < 285) || (deg <= 450 && deg > 435))
        {
            SpawnRandomEnemyAir( distance, radians);
        }else
        {
            SpawnRandomEnemyGround( distance, radians);
        }
    }
    private void SpawnRandomEnemyGround(float distance, double radians)
    {
        System.Random rand = new System.Random();
        GameObject enemy = groundEnemies[rand.Next(1,groundEnemies.Count)-1];
        SpawnEnemy(enemy,distance,radians);
    }
    private void SpawnRandomEnemyAir(float distance, double radians)
    {
        System.Random rand = new System.Random();
        GameObject enemy = airEnemies[rand.Next(1, airEnemies.Count) - 1];
        SpawnEnemy(enemy, distance, radians);
    }


    private void SpawnEnemy(GameObject unit,float distance,double radians) { 
    
        Vector3 v = getv(radians)*distance;
        Quaternion quat = Quaternion.FromToRotation(turret.transform.position,  v); //the direction from spawn to turret
        GameObject obj = Instantiate(unit,v,quat);
    }
    private Vector3 getv(double radians)
    {
        return new Vector3((float)Math.Sin(radians), (float)Math.Cos(radians),0);
    }
    

}
