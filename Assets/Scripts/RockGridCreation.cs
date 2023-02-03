using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGridCreation : MonoBehaviour
{
    public float xUnits = 6.0f;
    public float yUnits = 2.5f;

    [SerializeField] GameObject[] RockList;
    [SerializeField] Vector3 StartPostion;

    private void Start()
    {
        for(int i = 1; i < 4*8 ; i++)
        {
            if (i - 1 % 4 == 0)
        }
    }

}
