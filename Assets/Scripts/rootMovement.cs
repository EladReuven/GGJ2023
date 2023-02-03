using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootMovement : MonoBehaviour
{
    public float xUnits = 6.0f;
    public float yUnits = 2.5f;

    [SerializeField]
    GameObject rootBase;

    private void Start()
    {
        gameObject.transform.position = rootBase.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(yUnits, -xUnits, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-yUnits, -xUnits, 0);
        }
    }
}





