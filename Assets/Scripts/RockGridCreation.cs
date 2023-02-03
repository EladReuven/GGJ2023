using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGridCreation : MonoBehaviour
{
    public float xUnits = 6.0f;
    public float yUnits = 2.5f;

    [SerializeField] GameObject[] RockList;
    [SerializeField] GameObject[,] RockGrid;
    [SerializeField] Vector3 StartPostion;

    
    void CreateGrid()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i % 4 == 0)
            {

            }
        }
    }


}
