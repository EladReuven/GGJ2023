using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 3f;
    float currentTimer;

    private void Start()
    {
        currentTimer = timer;
    }

    private void OnEnable()
    {
        currentTimer = timer;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.SetActive(false);
    //        gameObject.SetActive(false);
    //    }
    //}


    private void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            if(currentTimer > 0)
            {
                currentTimer -= Time.deltaTime;
                Debug.Log(currentTimer);
            }

            if (currentTimer <= 0)
            {
                currentTimer = 3;
                gameObject.SetActive(false);
                
            }
        }
        
    }
}
