using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 3f;
    float currentTimer;

    [SerializeField] float speed = 5;

    Rigidbody rb;

    private void Start()
    {
        currentTimer = timer;
        rb = GetComponent<Rigidbody>();
        
    }


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        currentTimer = timer;
        rb.AddForce(transform.right * speed, ForceMode.VelocityChange);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "Sun")
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            GameManager.Instance.StarPower();
        }
    }


    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            
            if (currentTimer > 0)
            {
                currentTimer -= Time.deltaTime;
            }

            if (currentTimer <= 0)
            {
                gameObject.SetActive(false);
                rb.velocity= Vector3.zero;
                currentTimer = 3;
            }
        }
    }
}
