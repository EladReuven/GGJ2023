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
    public float radius;

    public void SpawnRandomEnemey()
    {
        float rand = UnityEngine.Random.value;
        double deg = (rand * 180) + 270f;
        double radians = deg / 360f * 2 * Math.PI;
        if ((deg >= 270 && deg < 285) || (deg <= 450 && deg > 435))
        {
            SpawnRandomEnemyGround(radians);
        }else
        {
            SpawnRandomEnemyAir(radians);
        }
    }
    private void SpawnRandomEnemyGround(double radians)
    {
        System.Random rand = new System.Random();
        GameObject enemy = groundEnemies[rand.Next(1,groundEnemies.Count)-1];
        SpawnEnemy(enemy,radians);
    }
    private void SpawnRandomEnemyAir(double radians)
    {
        System.Random rand = new System.Random();
        GameObject enemy = airEnemies[rand.Next(1, airEnemies.Count) - 1];
        SpawnEnemy(enemy, radians);
    }


    private void SpawnEnemy(GameObject unit,double radians) { 
    
        Vector3 v = getv(radians)*this.radius;
        Quaternion quat = Quaternion.FromToRotation(turret.transform.position,  v); //the direction from spawn to turret
        GameObject obj = Instantiate(unit,v,quat);
    }
    private Vector3 getv(double radians)
    {
        return new Vector3((float)Math.Sin(radians), (float)Math.Cos(radians),0);
    }
    

}
