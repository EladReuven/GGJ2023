using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float angleChangeRate;
    private Rigidbody rb;
    private bool up;
    [SerializeField] float speed;
    private float timer;
    [SerializeField] float turnTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioManager.instance.PlaySound("bird");
        rb.velocity = gameObject.transform.up * speed * -1;
        timer = turnTime/2f;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > turnTime)
        {
            timer = 0;
            up = !up;
        }
        ChangeLookDirection();
        ChangeSpeed();
    }
    private void ChangeLookDirection()
    {
        //this.transform.rotation.eulerAngles = Quaternion.ToEulerAngles(rb.velocity.
    }
    private void ChangeSpeed()
    {
        Vector2 v2 = new Vector2(rb.velocity.x, rb.velocity.y);
        Vector2 CounterClockwise = v2.Perpendicular1();
        Vector2 Clockwise = v2.Perpendicular2();

        if (up)
        {
            rb.AddForce(new Vector3(CounterClockwise.x, CounterClockwise.y).normalized * angleChangeRate, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(new Vector3(Clockwise.x, Clockwise.y).normalized * angleChangeRate, ForceMode.Acceleration);
        }
    }

    
}
